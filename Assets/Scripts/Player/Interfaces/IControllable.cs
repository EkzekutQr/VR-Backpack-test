using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    public void Jump();
    public void Move(Vector2 direction);
    public void ApplyVerticalMoving();
}
