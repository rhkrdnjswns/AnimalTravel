using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int numberOfStagesCleared = 0;

    private int currentStage;

    public int NumberOfStagesCleared { get => numberOfStagesCleared; }
    public static GameManager Instance { get => instance; set => instance = value; }
    public int CurrentStage { get => currentStage; set => currentStage = value; }

    private Dictionary<string, LoadSceneMode> loadSenes = new Dictionary<string, LoadSceneMode>();
    private static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance);
        
    }

    public void UpdateNumberOfStagesCleared()
    {
        numberOfStagesCleared++;
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main_Scene");
    }
    public void ReloadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadStageSelectScene()
    {
        SoundManager.Instance.PauseAudio();
        SceneManager.LoadScene("StageSelectScene");
        SoundManager.Instance.SetMainBGM();
    }
    public void BtnEvt_SelectStage(int stageNum)
    {
        SelectStage(stageNum);
    }
    public void SelectStage(int stageNum)
    {
        currentStage = stageNum;
        SoundManager.Instance.PauseAudio();
        SceneManager.LoadScene("SceneLoader");
        SoundManager.Instance.SetStageBGM(true);
    }
    
}
