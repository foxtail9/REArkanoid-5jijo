using System.Collections;
using System.Collections.Generic;
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
}
// title(intro) ���� �ٷ� �������� ������ �ƴ� �������� ��ư�� �������� ����, ���� ��ư�� �ִ� ȭ�鿡�� �������� ��ư�� ������ �������� ���� �г��� Ȱ��ȭ
// �޴� �߰�
// ���� ���� �߰�