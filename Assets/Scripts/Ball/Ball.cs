using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    private Vector2 ballDirection;
    private Vector2 ballPos = Vector2.zero;
    private float speed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ballDirection = Vector2.up.normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = ballDirection * speed;
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
                ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
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
