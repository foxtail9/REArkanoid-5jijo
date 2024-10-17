using UnityEngine;

public  class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    private int _row;
    private int _col;
    private int _space;

    public void GenerateStage(int level)
    {
        _row = 3 + level;
        _col = 5;

        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _col; j++)
            {
                // 벽돌 생성
                GameObject brickObject = Instantiate(brickPrefab);
                Brick brick = brickObject.GetComponent<Brick>();

                // 벽돌 색깔 지정
                string brickColor = "red";
                brick.Initialize(brickColor);

                // 벽돌 위치 설정
                brickObject.transform.position = new Vector3(j * (1 + _space) - 2, i * (0.5f + _space) + 3, 0);
            }
        }
    }
}
