using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public CanvasGroup fadeCg;
    public float fadeDuration = 1.0f;
    private int stageNum;
    private Dictionary<string, LoadSceneMode> loadScenes = new Dictionary<string, LoadSceneMode>();

    void initSceneInfo(int stageNum)
    {
        loadScenes.Clear();
        loadScenes.Add($"Game{stageNum}", LoadSceneMode.Additive);
        loadScenes.Add("Play", LoadSceneMode.Additive);
    }
    private void Awake()
    {
        stageNum = GameManager.Instance.CurrentStage;
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        initSceneInfo(stageNum);
        foreach (var item in loadScenes)
        {
            yield return StartCoroutine(LoadScene(item.Key, item.Value));
        }
        StartCoroutine(Fade(0.0f));
    }
    IEnumerator LoadScene(string sceneName, LoadSceneMode mode)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, mode);
        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(loadedScene);
    }
    IEnumerator Fade(float finalAlpha)
    {
       // SceneManager.SetActiveScene(SceneManager.GetSceneByName($"Game{stageNum}"));
        fadeCg.blocksRaycasts = true;
        float fadeSpeed = Mathf.Abs(fadeCg.alpha - finalAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeCg.alpha,finalAlpha))
        {
            fadeCg.alpha = Mathf.MoveTowards(fadeCg.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        fadeCg.blocksRaycasts = false;
        SceneManager.UnloadSceneAsync("SceneLoader");
    }
}
