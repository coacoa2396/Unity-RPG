using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
#if UNITY_EDITOR        // 전처리기(PreCompiler)
    string path => $"{Application.dataPath}/Data";
#else
    string path => $"{Application.persistentDataPath}/Data";
# endif 

    public GameData gameData;

    public void NewData()
    {
        gameData = new GameData();
        SaveData();
    }

    [ContextMenu("Save")]
    public void SaveData()
    {
        Debug.Log(path);

        if (Directory.Exists(path) == false)
        {
            Debug.Log("폴더가 없어서 생성합니다");
            Directory.CreateDirectory(path);
        }

        string filepath = Path.Combine(path, "Test.txt");
        string json = JsonUtility.ToJson(gameData, true);   // true 를 붙이면 보게좋게 만들어준다
                                                            // ToJson : 텍스트로 변환
        Debug.Log(json);

        File.WriteAllText(filepath, json);
    }

    [ContextMenu("Load")]
    public void LoadData()
    {
        string filePath = Path.Combine(path, "Test.txt");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);           // FromJson : 게임데이터로 변환

        }
        else
        {
            gameData = new GameData();

            // 새로 시작
        }
    }

    public bool ExistSaveData()
    {
        string filepath = Path.Combine(path, "Test.txt");
        return File.Exists(filepath);
    }
}




