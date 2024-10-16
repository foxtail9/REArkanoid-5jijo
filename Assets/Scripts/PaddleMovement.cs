using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private PaddleInputController paddleInputController;
    private Vector2 movementDirection = Vector2.zero;
    private float speed = 5f;

    private void Awake()
    {
        paddleInputController = GetComponent<PaddleInputController>();
    }

    private void Start()
    {
        paddleInputController.OnMoveEvent += Move;
    }

    private void Update()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;
    }
}
