using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;
    public static Manager Instance { get { return instance; } }

    [SerializeField] SceneManager sceneManager;
    [SerializeField] DataManager dataManager;
    public static SceneManager SceneManager { get { return instance.sceneManager; } }
    public static DataManager Data { get { return instance.dataManager; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
