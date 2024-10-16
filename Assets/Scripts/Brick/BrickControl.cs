using UnityEngine;

public class BrickControl : MonoBehaviour
{
    public void DestroyBrick()
    {
        Destroy(gameObject);
        // 벽돌에 붙어있는 스크립트
        // 점수 추가 로직 추가 구현 가능
    }
}