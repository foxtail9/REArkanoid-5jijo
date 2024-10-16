using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputContoller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();

        CallMoveEvent(moveInput);
    }
}
