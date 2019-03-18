using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public float DistancePerBlock = 1.05f;

    private GameState GS = GameState.Playing;
    private ItemArray matrix;
    private float ZIndex;
    public GameObject GO2, GO4, GO8, GO16, GO32, GO64, GO128, GO256, GO512, GO1024, GO_Blank;

    // Start is called before the first frame update
    void Start()
    {
        CreateGameBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //[yl] 创建棋盘
    private void CreateGameBoard()
    {
        if (matrix == null)
        {
            for (int row = 0; row < GlobalConst.RowsNum; ++row)
            {
                for (int col = 0; col < GlobalConst.ColumnsNum; ++col)
                {
                    Instantiate(GO_Blank, this.transform.position +
                        new Vector3(row * DistancePerBlock, col * DistancePerBlock, ZIndex), Quaternion.identity);
                }
            }
        }
    }
}
