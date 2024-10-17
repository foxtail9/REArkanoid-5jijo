using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 Item인지 확인
        if (collision.CompareTag("Item"))
        {
            // 아이템 효과 적용
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                ApplyItemEffect(item.itemType);
            }

            // 아이템 오브젝트 제거
            Destroy(collision.gameObject);
        }
    }

    // 아이템 효과 적용 로직
    private void ApplyItemEffect(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.PowerUp:
                Debug.Log("Paddle: PowerUp applied.");
                // 구슬 파워업 적용 로직
                BallManager.Instance.IncreaseBallPower();
                break;

            case ItemType.AddBall:
                Debug.Log("Paddle: AddBall applied.");
                // 추가 구슬 생성 로직
                BallManager.Instance.SpawnAdditionalBall();
                break;

            case ItemType.Increase:
                Debug.Log("Paddle: Increase Paddle size.");
                // 패들 크기 증가 로직
                IncreasePaddleSize();
                break;
        }
    }

    // 패들의 크기를 증가시키는 함수
    private void IncreasePaddleSize()
    {
        Vector3 newSize = transform.localScale;
        newSize.x += 1.0f; // 패들의 너비 증가
        transform.localScale = newSize;
    }
}
