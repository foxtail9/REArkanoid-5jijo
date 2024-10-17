using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    private void Start()
    {
        // �����ۿ� Rigidbody2D �߰��Ͽ� ���������� ����
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.0f; // �߷� ����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("deadline"))
        {
            Destroy(this.gameObject);
        }
    }
}
