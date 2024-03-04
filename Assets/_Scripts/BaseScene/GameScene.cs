using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Transform player;
    [SerializeField] CharacterController characterController;
    

    public override IEnumerator LoadingRoutine()
    {       
        yield return null;
        Debug.Log("·Îµù ³¡");
    }

    public void ToTitleScene()
    {
        Manager.SceneManager.LoadScene("TitleScene");
    }

    public override void SceneSave()
    {
        Manager.Data.gameData.sceneSaved[Manager.SceneManager.GetCurSceneIndex()] = true;
        Manager.Data.gameData.ganeSceneData.playerPos = player.position;
        Manager.Data.SaveData();
    }

    public override void SceneLoad()
    {
        if (Manager.Data.gameData.sceneSaved[Manager.SceneManager.GetCurSceneIndex()] == false)
        {
            return;
        }

        Manager.Data.LoadData();
        characterController.enabled = false;
        player.position = Manager.Data.gameData.ganeSceneData.playerPos;
        characterController.enabled = true;
    }
}
