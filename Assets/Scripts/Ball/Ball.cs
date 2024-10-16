using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigid;

    private Vector2 ballDirection;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

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
        if (collision.gameObject.CompareTag("brick"))
        {
            BrickControl brickControl = collision.gameObject.GetComponent<BrickControl>();

            if (brickControl != null)
            {
                brickControl.DestroyBrick();
                SetDirection(collision);
            }
        }

        if (collision.gameObject.CompareTag("wall"))
        {
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