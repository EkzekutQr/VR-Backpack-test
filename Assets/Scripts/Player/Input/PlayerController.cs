using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private IControllable controllable;
    private ICameraControllable cameraControllable;
    private IUsingControllable usingControllable;
    private GameInput gameinput;

    public GameInput Gameinput { get => gameinput; set => gameinput = value; }

    private void Awake()
    {
        gameinput = GameInputSingleton.Instance.GameInput;
        gameinput.Enable();
        controllable = GetComponent<IControllable>();
        cameraControllable = transform.GetComponentInChildren<ICameraControllable>();
        usingControllable = GetComponentInChildren<IUsingControllable>();

    }

    private void OnEnable()
    {
        gameinput.Gameplay.Jump.performed += OnJumpPerformed;
        gameinput.Gameplay.Using.performed += OnUsingPerformed;
    }

    private void OnDisable()
    {
        gameinput.Gameplay.Jump.performed -= OnJumpPerformed;
        gameinput.Gameplay.Using.performed -= OnUsingPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        controllable.Jump();
    }
    private void FixedUpdate()
    {
        ReadMovement();
        controllable.ApplyVerticalMoving();
        ReadRotation();
    }

    private void ReadMovement()
    {
        Vector2 inputDirection = gameinput.Gameplay.Movement.ReadValue<Vector2>();
        controllable.Move(inputDirection);
    }
    //private void LateUpdate()
    //{
    //    if (!photonView.IsMine) return;

    //    ReadRotation();
    //}
    private void ReadRotation()
    {
        Vector2 inputRotationDirection = gameinput.Gameplay.Rotation.ReadValue<Vector2>();
        cameraControllable.Rotate(inputRotationDirection);
    }
    private void OnUsingPerformed(InputAction.CallbackContext obj)
    {
        usingControllable.Use();
    }
}
