using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IControllable
{
    [SerializeField] float jumpStrength = 1f;
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float gravityMultiplier = 1f;
    [SerializeField] Vector3 playerVerticalVelocity;

    [SerializeField] bool isJumping;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Jump()
    {
        isJumping = true;
    }

    private void Jumping()
    {
        if (characterController.isGrounded)
        {
            playerVerticalVelocity = (Vector3.up * jumpStrength);
            Debug.Log("IsGrounded");
        }
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
            playerVerticalVelocity += (Physics.gravity * gravityMultiplier * Time.fixedDeltaTime);
        else
            playerVerticalVelocity = Vector3.zero;
    }

    public void ApplyVerticalMoving()
    {
        if (isJumping)
        {
            Jumping();
            isJumping = false;
        }
        characterController.Move(playerVerticalVelocity);

        ApplyGravity();
    }

    public void Move(Vector2 direction)
    {
        //characterController.Move(new Vector3(direction.x, 0, direction.y) * movementSpeed * Time.fixedDeltaTime);
        characterController.SimpleMove(((transform.forward * direction.y * movementSpeed) + (transform.right * direction.x * movementSpeed)) * Time.fixedDeltaTime);
    }
}
