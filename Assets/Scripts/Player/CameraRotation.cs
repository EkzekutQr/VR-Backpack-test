using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour, ICameraControllable
{
    [SerializeField] private float cameraSensitivity = 1f;
    [SerializeField] private Transform rotationTargetVertical;
    [SerializeField] private Transform rotationTargetHorizontal;

    private float vertical;
    private float horizontal;

    public void Rotate(Vector2 direction)
    {
        float dt = Time.deltaTime;

        vertical -= direction.y * cameraSensitivity * dt;
        horizontal += direction.x * cameraSensitivity * dt;

        rotationTargetVertical.localEulerAngles = new Vector3(vertical, 0f, 0f);
        rotationTargetHorizontal.localEulerAngles = new Vector3(0f, horizontal, 0f);
    }
}
