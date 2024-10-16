using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigid;
    private Vector2 direction;
    private float speed = 5f;

    private void Update()
    {
        //transform.position += dire
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            BrickControl brickControl = collision.gameObject.GetComponent<BrickControl>();

            if (brickControl != null)
            {
                brickControl.DestroyBrick();
            }
        }
    }
}
