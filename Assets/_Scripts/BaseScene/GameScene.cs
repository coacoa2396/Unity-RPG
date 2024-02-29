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
        Debug.Log("GameScene Load");
        // fake loading
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("Player Spawn");
        Manager.SceneManager.SetLoadingBarValue(0.55f);
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("������ƮǮ �غ�");
        Manager.SceneManager.SetLoadingBarValue(0.65f);

        for (int i = 0; i < count; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 3;
            Vector3 spawnPos = spawnPoint.position + new Vector3(randomOffset.x, 0, randomOffset.y);
            Monster monster = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);

            Debug.Log("���ͽ���");
            yield return new WaitForSecondsRealtime(0.5f);
        }
        Manager.SceneManager.SetLoadingBarValue(0.8f);

        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("�ε� ��");
    }

    public void ToTitleScene()
    {
        Manager.SceneManager.LoadScene("TitleScene");
    }
}
