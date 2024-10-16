using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Time.timeScale = 1.0f;
    }

    [SerializeField] private GameObject _paddle1;
    [SerializeField] private GameObject _paddle2;
    [SerializeField] private GameObject _brick;
    [SerializeField] private GameObject _ball;

    [SerializeField] private Text Life;
    [SerializeField] private Text Score;
    //[SerializeField] private GameObject GameOverPanel;

    private int _life = 3;
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_paddle1);
        Instantiate(_ball);

        // 스테이지 레벨에 따른 맵 생성
        Instantiate(_brick);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClear())
        {
            Time.timeScale = 0.0f;
        }
    }

    bool IsClear()
    {
        GameObject[] remain_bricks = GameObject.FindGameObjectsWithTag("brick");
        return remain_bricks.Length == 0;
    }

    public void GameOver()
    {
        //GameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void AddScore(int score)
    {
        this._score += score;
        Score.text = _score.ToString();
        IsClear();
    }

    public void LostLife()
    {
        _life--;
        Life.text = _life.ToString();

        if (_life < 1)
        {
            GameOver();
        }
        else
        {
            Instantiate(_ball);
        }
    }

}
