﻿/// <summary>
/// [yl] 游戏具体对象
/// </summary>
/// 
using UnityEngine;

public class GameItem
{
    public int Value { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public  GameObject GO{ get; set; }
    public bool WasJustDuplicated { get; set; }

}
