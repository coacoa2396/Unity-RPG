using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public string name;
    public int level;
    public int gold;
    public int exp;

    public bool[] sceneSaved;
    public GameSceneData ganeSceneData;
    

    public GameData()
    {
        name = "플레이어";
        level = 1;
        gold = 0;
        exp = 0;

        sceneSaved = new bool[32];
        ganeSceneData = new GameSceneData();
    }
}

