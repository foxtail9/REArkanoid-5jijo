using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputContoller : PlayerEventManager
{    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        CallMoveEvent(moveInput);
    }
}
