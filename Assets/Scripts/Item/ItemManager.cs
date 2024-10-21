using UnityEngine;


// ������ Ÿ�� ����
public enum ItemType
{
    PowerUp,   // ���� �Ŀ� ��
    AddBall,   // ���� �߰�
    Increase   // �е� Ȯ��
}

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;  // �̱��� ����

    public GameObject powerUpPrefab;     // �Ŀ��� ������ ������
    public GameObject addBallPrefab;     // ���� �߰� ������ ������
    public GameObject increasePaddlePrefab; // �е� Ȯ�� ������ ������

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ������ ���� �Լ�
    public void SpawnItem(Vector3 position)
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= 30f)
        {
            // ������ ���� �� �� (70% Ȯ��)
            return;
        }

        ItemType itemType = GetRandomItemType();
        GameObject itemPrefab = null;

        // ������ Ÿ�Կ� ���� ������ ����
        switch (itemType)
        {
            case ItemType.PowerUp:
                itemPrefab = powerUpPrefab;
                break;
            case ItemType.AddBall:
                itemPrefab = addBallPrefab;
                break;
            case ItemType.Increase:
                itemPrefab = increasePaddlePrefab;
                break;
        }

        // ������ ����
        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, position, Quaternion.identity);
        }
    }

    // �������� ������ Ÿ���� �����ϴ� �Լ�
    private ItemType GetRandomItemType()
    {
        float randomValue = Random.Range(0f, 31f);
        if (randomValue < 10f)
        {
            return ItemType.PowerUp;
        }
        else if (randomValue < 20f)
        {
            return ItemType.AddBall;
        }
        else
        {
            return ItemType.Increase;
        }
    }
}

