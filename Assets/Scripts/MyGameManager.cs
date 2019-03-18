using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public float DistancePerBlock = 1.05f;

    private GameState GS = GameState.Playing;
    private ItemArray matrix;
    private float ZIndex = 0f;
    public GameObject GO2, GO4, GO8, GO16, GO32, GO64, GO128, GO256, GO512, GO1024, GO_Blank;

    // Start is called before the first frame update
    void Start()
    {
        CreateGameBoard();
        Initialize();
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

    //[yl] 初始化
    public void Initialize()
    {
        if (matrix != null)
        {
            for (int row = 0; row < GlobalConst.RowsNum; ++row)
            {
                for (int col = 0; col < GlobalConst.ColumnsNum; ++col)
                {
                    var tempValue = matrix[row, col];
                    if (tempValue != null && tempValue.GO != null)
                    {
                        Destroy(tempValue.GO);
                        matrix[row, col] = null;
                    }
                }
            }
        }

        matrix = new ItemArray();

        CreateNewItem();
        CreateNewItem();

        GS = GameState.Playing;
    }

    //[yl] 创建新对象
    private void CreateNewItem(int value = 2, int? row = null, int? col = null)
    {
        int emptyRow, emptyCol;
        if (row == null && col == null)
        {
            matrix.GetRandomRowCol(out emptyRow, out emptyCol);
        }
        else
        {
            emptyRow = row.Value;
            emptyCol = col.Value;
        }

        var newItem = new GameItem();
        newItem.Value = value;
        newItem.Row = emptyRow;
        newItem.Column = emptyCol;

        var go = GetGOByValue(value);
        if(go == null)
        {
            Debug.LogError("Error value:" + value);
            return;
        }

        //[yl]anim
        go.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        newItem.GO = Instantiate(go, this.transform.position + 
            new Vector3(emptyRow * DistancePerBlock, emptyCol * DistancePerBlock, ZIndex), Quaternion.identity) as GameObject;
        newItem.GO.transform.scaleTo(GlobalConst.AnimDuration, new Vector3(1, 1, 1));

        matrix[emptyRow, emptyCol] = newItem;
    }

    //[yl] 通过值获取对应预制体
    private GameObject GetGOByValue(int value)
    {
        GameObject go = null;
        switch(value)
        {
            case 2:go = GO2;break;
            case 4:go = GO4;break;
            case 8:go = GO8;break;
            case 16:go = GO16;break;
            case 32:go = GO32;break;
            case 64:go = GO64;break;
            case 128:go = GO128;break;
            case 256:go = GO256;break;
            case 512:go = GO512;break;
            case 1024:go = GO1024;break;
        }
        return go;
    }
}
