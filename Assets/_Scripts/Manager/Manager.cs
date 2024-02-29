using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;
    public static Manager Instance { get { return instance; } }

    [SerializeField] SceneManager sceneManager;
    public static SceneManager SceneManager { get { return instance.sceneManager; } }

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
