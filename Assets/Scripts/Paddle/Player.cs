using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    private Vector3 originalSize; // 원래 크기를 저장할 변수
    private float maxSize = 3.0f; // 최대 크기 제한
    public AudioSource audioSource;  // 패들에서 사용할 AudioSource
    public AudioClip ballCatchSound;  // 구슬 받기 사운드

    private void Awake()
    {
        // 원래 패들의 크기를 저장
        originalSize = transform.localScale;
    }

    private void Start()
    {
        // AudioSource가 자동으로 재생되지 않도록 설정
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            PlayBallCatchSound();
        }
    }
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

    void PlayBallCatchSound()
    {
        if (audioSource != null && ballCatchSound != null)
        {
            audioSource.PlayOneShot(ballCatchSound);
        }
    }

    // 아이템 효과 적용 로직
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

    // 패들의 크기를 증가시키는 함수
    private void IncreasePaddleSize()
    {
        // 현재 패들의 크기가 최대 크기를 초과하지 않도록 검사
        if (transform.localScale.x < maxSize)
        {
            Vector3 newSize = transform.localScale;
            newSize.x = Mathf.Min(newSize.x + 1.0f, maxSize); // 최대 크기 제한
            transform.localScale = newSize;

            // 원래 크기로 돌아오는 코루틴 실행
            StartCoroutine(ResetPaddleSizeAfterTime(6f)); // 6초 후에 원래 크기로 되돌림
        }
    }

    // 6초 후 패들을 원래 크기로 되돌리는 코루틴
    private IEnumerator ResetPaddleSizeAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay); // 지정된 시간만큼 기다림
        transform.localScale = originalSize; // 원래 크기로 되돌림
    }
   
}
