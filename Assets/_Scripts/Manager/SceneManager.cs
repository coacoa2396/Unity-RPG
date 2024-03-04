using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image fade;
    [SerializeField] Slider loadingBar;

    BaseScene curScene;

    public BaseScene GetCurScene()
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<BaseScene>();
        }

        return curScene;
    }

    // 아래는 일반화 버전
    public T GetCurScene<T>() where T : BaseScene
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<BaseScene>();
        }

        return curScene as T;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        Time.timeScale = 0.1f;
        loadingBar.gameObject.SetActive(true);
        // 암전(Fade Out)
        float time = 0f;
        while (time < 0.5f)
        {
            time += Time.unscaledDeltaTime;
            fade.color = new Color(0, 0, 0, time * 2);

            yield return null;
        }

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);      // 비동기식으로 백그라운드에 다음 씬을 로당하는 방법
        //oper.allowSceneActivation = false;          // 로딩이 되어있지만 대기하는 상태
        while (oper.isDone == false)        // oper.progress < 0.9f는 스페이스바 누르는버전인 경우 사용
        {
            loadingBar.value = Mathf.Lerp(0f, 0.5f, oper.progress);
            Debug.Log(oper.progress);
            yield return null;
        }

        // space 누르기 전에는 로딩이 안됨
        //yield return new WaitUntil(() => { return Input.GetKeyDown(KeyCode.Space); });
        //oper.allowSceneActivation = true;

        yield return new WaitForSeconds(0.1f);

        BaseScene curScene = GetCurScene();
        yield return curScene.LoadingRoutine();
        Time.timeScale = 1f;
        Manager.SceneManager.SetLoadingBarValue(1f);

        yield return new WaitForSeconds(0.3f);

        loadingBar.gameObject.SetActive(false);

        // Fade In
        time = 0.5f;
        while (time > 0f)
        {
            time -= Time.unscaledDeltaTime;
            fade.color = new Color(0, 0, 0, time * 2);
            yield return null;
        }
    }

    public void SetLoadingBarValue(float value)
    {
        loadingBar.value = value;
    }
}
