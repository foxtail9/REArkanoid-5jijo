using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    [SerializeField] private GameObject ballPrefab;
    private void Awake()
    {
        Instance = this;
    }

    // 구슬의 파워를 증가시키는 함수
    public void IncreaseBallPower()
    {
        // 현재 구슬의 파워 증가 처리
        GameManager.Instance.ballpower += 1f;
        StartCoroutine(ResetBallPowerAfterTime(10f));
    }
    private IEnumerator ResetBallPowerAfterTime(float delay)
    {
        // 지정된 시간만큼 기다림
        yield return new WaitForSeconds(delay);

        // ballpower를 감소시키는 로직
        GameManager.Instance.ballpower -= 1f; // 증가했던 만큼 감소
        Debug.Log($"Ball power decreased! Current ballpower: {GameManager.Instance.ballpower}");
    }

    // 추가 구슬을 생성하는 함수
    public void SpawnAdditionalBall()
    {
        // 추가 구슬 생성 로직
        Instantiate(ballPrefab, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        // 현재 패들의 위치를 기준으로 구슬이 떨어질 위치를 설정
        Vector3 paddlePosition = GameObject.FindGameObjectWithTag("player").transform.position;
        return new Vector3(paddlePosition.x, paddlePosition.y + 1f, 0); // 패들 위쪽에 스폰
    }
}
