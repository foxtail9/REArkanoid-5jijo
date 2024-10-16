using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 ballDirection;
    private Vector2 ballPos = Vector2.zero;
    private float speed = 5f;

    private void Start()
    {
        ballDirection = Vector2.up.normalized;
    }

    private void FixedUpdate()
    {
        myRigid.velocity = ballDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (!collision.gameObject.CompareTag("deadline"))
        {
            if (collision.gameObject.CompareTag("player"))
            {
<<<<<<< HEAD:Assets/Scripts/Ball/Ball.cs
                brickControl.DestroyBrick();
                SetDirection(collision);
=======
                float hitPoint = collision.contacts[0].point.x;
                float paddleCenter = collision.transform.position.x;
                float angle = (hitPoint - paddleCenter) * 2f;
                ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
            }
            else
            {
                ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
>>>>>>> JuSung:Assets/Scripts/Ball.cs
            }
        }
        else
        {
<<<<<<< HEAD:Assets/Scripts/Ball/Ball.cs
            SetDirection(collision);
            return;
        }

        if (collision.gameObject.CompareTag("player"))
        {
            float hitPoint = collision.contacts[0].point.x;
            float paddleCenter = collision.transform.position.x;

            float angle = (hitPoint - paddleCenter) * 2f;

            SetDirection(collision);
        }
    }

    private void SetDirection(Collision2D collision)
    {
        ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
        myRigid.velocity = ballDirection * speed;
    }
}
=======
            GameManager.Instance.LostLife();
            Destroy(this.gameObject);
        }
    }

}
>>>>>>> JuSung:Assets/Scripts/Ball.cs
