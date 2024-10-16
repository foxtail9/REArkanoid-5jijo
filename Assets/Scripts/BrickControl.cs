using UnityEngine;

public class BrickControl : MonoBehaviour
{
    public void DestroyBrick()
    {
        Destroy(gameObject);
        // 벽돌에 붙어있는 스크립트
        // 공과 충돌하면 해당 메서드가 실행됨
    }
}