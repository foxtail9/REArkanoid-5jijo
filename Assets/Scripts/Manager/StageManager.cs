using UnityEngine;

public  class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    private int _row;
    private int _col;
    private float _space = 0.1f;

    public void GenerateStage(int level)
    {
        _row = 3 + level;
        _col = 6;

        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _col; j++)
            {
                // 벽돌 생성
                GameObject brickObject = Instantiate(brickPrefab);
                Brick brick = brickObject.GetComponent<Brick>();

                // 벽돌 색깔 지정
                string brickColor = "red";
                switch (i){
                    case 0:
                        brickColor = "purple";
                        break;
                    case 1:
                        brickColor = "green";
                        break;
                    case 2:
                        brickColor = "yellow";
                        break;
                }
                brick.Initialize(brickColor);

                // 벽돌 위치 설정
                brickObject.transform.position = new Vector3(j * (0.75f + _space) - 2.1f, -i * (0.25f + _space) + 4, 0);
            }
        }
    }
}
