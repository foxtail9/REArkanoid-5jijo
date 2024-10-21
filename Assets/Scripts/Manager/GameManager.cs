using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject stageManagerPrefab;

    [SerializeField] private GameObject _paddle1;
    [SerializeField] private GameObject _paddle2;
    [SerializeField] private GameObject _brick;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _deadline;
    [SerializeField] public float ballpower = 1f;

    [SerializeField] private Text Life;
    [SerializeField] private Text Score;
    [SerializeField] private Text TimeText;
    //[SerializeField] private GameObject GameOverPanel;

    private int _life = 3;
    private int _score = 0;
    private float _time = 180.0f;

    private StageManager stageManager;
    public AudioSource bgmSource;  // BGM 재생을 위한 AudioSource
    public AudioClip bgmClip;      // BGM 클립

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
        stageManager = Instantiate(stageManagerPrefab).GetComponent<StageManager>();

        // 벽 생성
        Instantiate(_wall);
        Instantiate(_deadline);

        // 벽돌 생성
        stageManager.GenerateStage(1);

        // 패들 및 공 생성
        Instantiate(_paddle1);
        Instantiate(_ball);
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        Score.text = _score.ToString();
        TimeText.text = _time.ToString("N2");

        if (!IsAlive())
        {
            LostLife();
        }

        if (IsClear() || _time <= 0.0f)
        {
            Time.timeScale = 0.0f;
        }
    }

    void PlayBGM()
    {
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;  // BGM은 루프될 수 있음
            bgmSource.Play();
        }
    }

    bool IsClear()
    {
        GameObject[] remain_bricks = GameObject.FindGameObjectsWithTag("brick");
        if(remain_bricks.Length == 0)
        {
            _score += (int)_time * 13;
            _time = 0.0f;
            return true;
        }
        return false;
    }

    public void GameOver()
    {
        //GameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void AddScore(int score)
    {
        this._score += score;
    }

    bool IsAlive()
    {
        GameObject[] remain_balls = GameObject.FindGameObjectsWithTag("ball");
        if (remain_balls.Length > 0)
            return true;
        return false;
    }

    public void LostLife()
    {
        _life--;

        if (_life < 1)
        {
            _life = 0;
            GameOver();
        }
        else
        {
            Instantiate(_ball);
        }

        Life.text = _life.ToString();
    }

    public void BrickDestroyed(Vector3 position) //Brick에게 스폰요청
    {
        ItemManager.Instance.SpawnItem(position);
    }
}
