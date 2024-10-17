using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� Item���� Ȯ��
        if (collision.CompareTag("Item"))
        {
            // ������ ȿ�� ����
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                ApplyItemEffect(item.itemType);
            }

            // ������ ������Ʈ ����
            Destroy(collision.gameObject);
        }
    }

    // ������ ȿ�� ���� ����
    private void ApplyItemEffect(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.PowerUp:
                Debug.Log("Paddle: PowerUp applied.");
                // ���� �Ŀ��� ���� ����
                BallManager.Instance.IncreaseBallPower();
                break;

            case ItemType.AddBall:
                Debug.Log("Paddle: AddBall applied.");
                // �߰� ���� ���� ����
                BallManager.Instance.SpawnAdditionalBall();
                break;

            case ItemType.Increase:
                Debug.Log("Paddle: Increase Paddle size.");
                // �е� ũ�� ���� ����
                IncreasePaddleSize();
                break;
        }
    }

    // �е��� ũ�⸦ ������Ű�� �Լ�
    private void IncreasePaddleSize()
    {
        Vector3 newSize = transform.localScale;
        newSize.x += 1.0f; // �е��� �ʺ� ����
        transform.localScale = newSize;
    }
}
