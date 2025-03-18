using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseRotationInput : MonoBehaviour
{
    public event Action<Vector2> RotationInputReceived;

    public MouseRotationInput(GameInput gameInput)
    {
        gameInput.Gameplay.Rotation.performed += context =>
        {
            var mouseDelta = context.ReadValue<Vector2>();

            RotationInputReceived?.Invoke(mouseDelta);
        };
    }
}
