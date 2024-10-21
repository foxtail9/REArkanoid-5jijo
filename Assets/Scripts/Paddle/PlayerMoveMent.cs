using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputContoller playerInputContoller;
    private Rigidbody2D _rigidbody;

    private Vector2 movementDirection = Vector2.zero;
    private float _speed = 5f;

    private void Awake()
    {
        playerInputContoller = GetComponent<PlayerInputContoller>();
        _rigidbody = GetComponent<Rigidbody2D>();
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
        Vector2 velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = velocity;

        //transform.position += new Vector3(direction.x, 0, 0) * _speed * Time.deltaTime;
    }
}
