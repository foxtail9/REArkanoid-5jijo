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
// title(intro) 씬에 바로 스테이지 선택이 아닌 게임종료 버튼과 스테이지 선택, 설정 버튼이 있는 화면에서 스테이지 버튼을 누르면 스테이지 선택 패널이 활성화
// 메뉴 추가
// 게임 종료 추가