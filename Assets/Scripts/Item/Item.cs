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

}
