using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 ballDirection;
    private Vector2 ballPos = Vector2.zero;

    private float _time = 0.0f;
    private float speed = 5f;

    private void Start()
    {
        ballDirection = Vector2.down.normalized;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if(_time >= 10.0f)
        {
            _time = 0.0f;
            speed *= 1.05f;
            Debug.Log(this.speed);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = ballDirection.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (!collision.gameObject.CompareTag("deadline"))
        {
            if (collision.gameObject.CompareTag("player"))
            {
                float hitPoint = collision.contacts[0].point.x;
                float paddleCenter = collision.transform.position.x;

                float angle = (hitPoint - paddleCenter) * 2f;

                angle = Mathf.Clamp(angle, -1.3f, 1.3f);

                ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

                _rigidbody.velocity = ballDirection * speed;
            }
            else
            {
                ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
