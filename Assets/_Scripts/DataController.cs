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
            Debug.Log("������ ��� �����մϴ�");
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
            Debug.Log("����� ���̺����� ����");
            // ���� ����
        }
    }
}
