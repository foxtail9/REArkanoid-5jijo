using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputContoller playerInputContoller;
    private Vector2 movementDirection = Vector2.zero;
    private float _speed = 5f;

    private void Awake()
    {
        playerInputContoller = GetComponent<PlayerInputContoller>();
    }

    private void Start()
    {
        playerInputContoller.OnMoveEvent += Move;
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
        transform.position += new Vector3(direction.x, 0, 0) * _speed * Time.deltaTime;
    }
}
