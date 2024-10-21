using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestNYChangeSceneController : MonoBehaviour
{
    [SerializeField] private string scene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("TestNYMain");
    }

    //public void GameOverScene()
    //{
    //    bool over = GameManager.Instance.GameOver();
    //    if (over)
    //    {
    //        SceneManager.LoadScene("TestNYGameOver");
    //    }
    //}
}
// title(intro) ���� �ٷ� �������� ������ �ƴ� �������� ��ư�� �������� ����, ���� ��ư�� �ִ� ȭ�鿡�� �������� ��ư�� ������ �������� ���� �г��� Ȱ��ȭ
// �޴� �߰�
// ���� ���� �߰�

// ���ӸŴ����� GameOver�Լ��� bool�� �����ؼ� ���� ���������� ��ȯ�� �ϰ� ����.