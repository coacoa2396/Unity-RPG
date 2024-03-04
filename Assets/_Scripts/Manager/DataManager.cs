using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
#if UNITY_EDITOR        // ��ó����(PreCompiler)
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
            Debug.Log("������ ��� �����մϴ�");
            Directory.CreateDirectory(path);
        }

        string filepath = Path.Combine(path, "Test.txt");
        string json = JsonUtility.ToJson(gameData, true);   // true �� ���̸� �������� ������ش�
                                                            // ToJson : �ؽ�Ʈ�� ��ȯ
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
            gameData = JsonUtility.FromJson<GameData>(json);           // FromJson : ���ӵ����ͷ� ��ȯ

        }
        else
        {
            gameData = new GameData();

            // ���� ����
        }
    }

    public bool ExistSaveData()
    {
        string filepath = Path.Combine(path, "Test.txt");
        return File.Exists(filepath);
    }
}




