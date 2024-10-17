using UnityEngine;


// 아이템 타입 정의
public enum ItemType
{
    PowerUp,   // 구슬 파워 업
    AddBall,   // 구슬 추가
    Increase   // 패들 확장
}

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;  // 싱글톤 패턴

    public GameObject powerUpPrefab;     // 파워업 아이템 프리팹
    public GameObject addBallPrefab;     // 구슬 추가 아이템 프리팹
    public GameObject increasePaddlePrefab; // 패들 확장 아이템 프리팹

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

    // 아이템 생성 함수
    public void SpawnItem(Vector3 position)
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= 30f)
        {
            // 아이템 생성 안 함 (70% 확률)
            return;
        }

        ItemType itemType = GetRandomItemType();
        GameObject itemPrefab = null;

        // 아이템 타입에 따른 프리팹 선택
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

        // 아이템 생성
        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, position, Quaternion.identity);
        }
    }

    // 랜덤으로 아이템 타입을 결정하는 함수
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

