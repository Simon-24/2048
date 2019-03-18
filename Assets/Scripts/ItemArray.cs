using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemArray
{
    private GameItem[,] ItemMatrix = new GameItem[GlobalConst.RowsNum, GlobalConst.ColumnsNum];
    
    //[yl] indexer for class
    public GameItem this[int row, int column]
    {
        get
        {
            return ItemMatrix[row, column];
        }

        set
        {
            ItemMatrix[row, column] = value;
        }
    }

}   