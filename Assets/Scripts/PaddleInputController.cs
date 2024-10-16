using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleInputController : Controller
{
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        CallMoveEvent(moveInput);
    }
}
