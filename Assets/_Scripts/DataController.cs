using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    [ContextMenu("Save")]
    public void Save()
    {
        if (Directory.Exists($"{Application.dataPath}/Data") == false)
        {
            Debug.Log("폴더가 없어서 생성합니다");
            Directory.CreateDirectory($"{Application.dataPath}/Data");
        }

        string path = Path.Combine(Application.dataPath, "Data/Test.txt");
        File.WriteAllText(path, "ABCDEFG");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "Data/Test.txt");
        if (File.Exists(path))
        {
            string text = File.ReadAllText(path);
            Debug.Log(text);
        }
        else
        {
            Debug.Log("저장된 세이브파일 없음");
            // 새로 시작
        }
    }
}
