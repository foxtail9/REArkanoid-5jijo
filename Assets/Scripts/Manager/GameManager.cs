using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = new GameManager();
        }

        Time.timeScale = 1.0f;
    }

    [SerializeField] private GameObject _paddle;
    [SerializeField] private GameObject _brick;
    [SerializeField] private GameObject _ball;

    [SerializeField] private GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        // 스테이지 레벨에 따른 맵 생성
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Score()
    {

    }
}
