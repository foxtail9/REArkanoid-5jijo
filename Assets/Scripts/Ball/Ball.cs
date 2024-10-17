using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 ballDirection;
    private Vector2 ballPos = Vector2.zero;
    private float speed = 5f;

    private void Start()
    {
        ballDirection = Vector2.down.normalized;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
                ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            }
            else
            {
                ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
            }
        }
        else
        {
            GameManager.Instance.LostLife();
            Destroy(this.gameObject);
        }
    }

}
