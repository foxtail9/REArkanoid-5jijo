using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    private void Start()
    {
        // 아이템에 Rigidbody2D 추가하여 떨어지도록 설정
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.0f; // 중력 설정
    }

}
