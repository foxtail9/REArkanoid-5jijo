using UnityEngine;

public class BrickControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 점수 추가 로직
            Destroy(gameObject);
        }
    }
}