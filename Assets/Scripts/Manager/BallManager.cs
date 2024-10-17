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

    // ������ �Ŀ��� ������Ű�� �Լ�
    public void IncreaseBallPower()
    {
        // ���� ������ �Ŀ� ���� ó��
        GameManager.Instance.ballpower += 1f;
        StartCoroutine(ResetBallPowerAfterTime(10f));
    }
    private IEnumerator ResetBallPowerAfterTime(float delay)
    {
        // ������ �ð���ŭ ��ٸ�
        yield return new WaitForSeconds(delay);

        // ballpower�� ���ҽ�Ű�� ����
        GameManager.Instance.ballpower -= 1f; // �����ߴ� ��ŭ ����
        Debug.Log($"Ball power decreased! Current ballpower: {GameManager.Instance.ballpower}");
    }

    // �߰� ������ �����ϴ� �Լ�
    public void SpawnAdditionalBall()
    {
        // �߰� ���� ���� ����
        Instantiate(ballPrefab, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        // ���� �е��� ��ġ�� �������� ������ ������ ��ġ�� ����
        Vector3 paddlePosition = GameObject.FindGameObjectWithTag("player").transform.position;
        return new Vector3(paddlePosition.x, paddlePosition.y + 1f, 0); // �е� ���ʿ� ����
    }
}
