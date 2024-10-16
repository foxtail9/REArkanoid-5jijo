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

    private void Update()
    {
        transform.position += new Vector3(ballDirection.x, ballDirection.y, 0) * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            BrickControl brickControl = collision.gameObject.GetComponent<BrickControl>();

            if (brickControl != null)
            {
                brickControl.DestroyBrick();
            }

            ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
            return;
        }

        if (collision.gameObject.CompareTag("player"))
        {
            float hitPoint = collision.contacts[0].point.x;
            float paddleCenter = collision.transform.position.x;

            float angle = (hitPoint - paddleCenter) * 2f;

            ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
        }
    }
}