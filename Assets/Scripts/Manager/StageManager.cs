using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    private float _space = 0.05f;

    private int[][][] stageData = new int[][][]
    {
        new int[][]
        {
            new int[] { 1, 0, 0, 0, 0, 0, 1 },
            new int[] { 0, 0, 1, 0, 1, 0, 0 },
            new int[] { 0, 1, 2, 1, 2, 1, 0 },
            new int[] { 1, 2, 3, 2, 3, 2, 1 },
            new int[] { 1, 2, 3, 3, 3, 2, 1 },
            new int[] { 0, 1, 2, 2, 2, 1, 0 },
            new int[] { 0, 0, 1, 1, 1, 0, 0 },
            new int[] { 0, 0, 0, 1, 0, 0, 0 },
            new int[] { 1, 0, 0, 0, 0, 0, 1 }
        },

        new int[][]
        {   
            new int[] { 1, 1, 1, 1, 1, 1, 1 },
            new int[] { 1, 0, 0, 4, 0, 0, 1 },
            new int[] { 1, 0, 4, 3, 4, 0, 1 },
            new int[] { 1, 4, 3, 2, 3, 4, 1 },
            new int[] { 1, 3, 2, 0, 2, 3, 4 },
            new int[] { 1, 4, 3, 2, 3, 4, 1 },
            new int[] { 1, 0, 4, 3, 4, 0, 1 },
            new int[] { 1, 0, 0, 4, 0, 0, 1 },
            new int[] { 1, 1, 1, 1, 1, 1, 1 },
        },

        new int[][]
        {
            new int[] { 4, 1, 1, 1, 1, 1, 4 },
            new int[] { 1, 2, 2, 2, 2, 2, 1 },
            new int[] { 1, 2, 3, 3, 3, 2, 1 },
            new int[] { 1, 2, 3, 4, 3, 2, 1 },
            new int[] { 1, 2, 3, 4, 3, 2, 1 },
            new int[] { 1, 2, 3, 4, 3, 2, 1 },
            new int[] { 1, 2, 3, 3, 3, 2, 1 },
            new int[] { 1, 2, 2, 3, 2, 2, 1 },
            new int[] { 4, 1, 1, 1, 1, 1, 4 }
        }
    };

    public void GenerateStage(int level)
    {
        if (level < 1 || level > stageData.Length)
        {
            Debug.LogError("Invalid level number!");
            return;
        }

        int[][] selectedStage = stageData[level - 1];

        float brickWidth = 0.75f;
        float brickHeight = 0.25f;
        float xSpacing = brickWidth + _space;
        float ySpacing = brickHeight + _space;

        float totalGridWidth = selectedStage[0].Length * xSpacing;

        Vector3 startPosition = new Vector3(-totalGridWidth / 2.35f, 4.15f, 0);

        for (int i = 0; i < selectedStage.Length; i++)
        {
            for (int j = 0; j < selectedStage[i].Length; j++)
            {
                int brickType = selectedStage[i][j];
                if (brickType == 0) continue;

                GameObject brickObject = Instantiate(brickPrefab);
                Brick brick = brickObject.GetComponent<Brick>();

                string brickColor = "red";
                switch (brickType)
                {
                    case 1: brickColor = "red"; break;
                    case 2: brickColor = "yellow"; break;
                    case 3: brickColor = "green"; break;
                    case 4: brickColor = "purple"; break;
                }
                brick.Initialize(brickColor);

                brickObject.transform.localScale = new Vector3(brickWidth, brickHeight, 1f);

                Vector3 brickPosition = new Vector3(j * xSpacing, -i * ySpacing, 0) + startPosition;
                brickObject.transform.position = brickPosition;
            }
        }
    }
}


