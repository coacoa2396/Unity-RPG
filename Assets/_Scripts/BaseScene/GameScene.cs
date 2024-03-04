using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Monster monsterPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int count;

    public override IEnumerator LoadingRoutine()
    {
       
        yield return null;
        Debug.Log("·Îµù ³¡");
    }

    public void ToTitleScene()
    {
        Manager.SceneManager.LoadScene("TitleScene");
    }
}
