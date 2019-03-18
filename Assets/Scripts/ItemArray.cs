using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemArray
{
    private System.Random rand = new System.Random();

    private GameItem[,] itemMatrix = new GameItem[GlobalConst.RowsNum, GlobalConst.ColumnsNum];
    
    //[yl] indexer for class
    public GameItem this[int row, int column]
    {
        get
        {
            return itemMatrix[row, column];
        }

        set
        {
            itemMatrix[row, column] = value;
        }
    }

    public void GetRandomRowCol(out int row, out int col)
    {
        do
        {
            row = rand.Next(0, GlobalConst.RowsNum);
            col = rand.Next(0, GlobalConst.ColumnsNum);
        } while (itemMatrix[row, col] != null);
    }
}   