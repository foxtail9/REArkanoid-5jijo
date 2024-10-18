using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    private Vector3 originalSize; // ���� ũ�⸦ ������ ����
    private float maxSize = 3.0f; // �ִ� ũ�� ����

    private void Awake()
    {
        // ���� �е��� ũ�⸦ ����
        originalSize = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� Item���� Ȯ��
        if (collision.CompareTag("Item"))
        {
            Debug.Log("������ ����");
            // ������ ȿ�� ����
            Item item = collision.GetComponent<Item>();

            if (item != null)
            {
                Debug.Log("���� ������ :" + item.itemType);
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
                BallManager.Instance.IncreaseBallPower();
                break;

            case ItemType.AddBall:
                BallManager.Instance.SpawnAdditionalBall();
                break;

            case ItemType.Increase:
                IncreasePaddleSize();
                break;
        }
    }

    // �е��� ũ�⸦ ������Ű�� �Լ�
    private void IncreasePaddleSize()
    {
        // ���� �е��� ũ�Ⱑ �ִ� ũ�⸦ �ʰ����� �ʵ��� �˻�
        if (transform.localScale.x < maxSize)
        {
            Vector3 newSize = transform.localScale;
            newSize.x = Mathf.Min(newSize.x + 1.0f, maxSize); // �ִ� ũ�� ����
            transform.localScale = newSize;

            // ���� ũ��� ���ƿ��� �ڷ�ƾ ����
            StartCoroutine(ResetPaddleSizeAfterTime(6f)); // 6�� �Ŀ� ���� ũ��� �ǵ���
        }
    }

    // 6�� �� �е��� ���� ũ��� �ǵ����� �ڷ�ƾ
    private IEnumerator ResetPaddleSizeAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay); // ������ �ð���ŭ ��ٸ�
        transform.localScale = originalSize; // ���� ũ��� �ǵ���
    }
   
}
