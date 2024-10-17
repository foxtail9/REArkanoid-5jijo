using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // ������ �Ŀ��� ������Ű�� �Լ�
    public void IncreaseBallPower()
    {
        // ���� ������ �Ŀ� ���� ó��
        Debug.Log("�Ŀ���!!");
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
        Debug.Log("���� ����!");
        // �߰� ���� ���� ����
        // Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }
}
