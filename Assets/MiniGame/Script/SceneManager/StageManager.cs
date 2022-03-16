using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private const int STAGE_COUNT = 3;

    private static StageManager instance = null;

    [SerializeField] private static Stage[] stages;

    private int currentStage;
    public static StageManager Instance { get => instance; set => instance = value; }
    public int CurrentStage { get => currentStage; set => currentStage = value; }

    private void Awake()
    {
        /*if(stages == null)
        {
            stages = GameObject.Find("StageArea").GetComponentsInChildren<Stage>();
        }    */
    }
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < stages.Length; i++)
        {
            Debug.Log(stages[i].IsOpen);
        }
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);         
        }
        DontDestroyOnLoad(instance);*/
    }
    public void SelectStage(Stage stage)
    {
        if (!stage.IsOpen) return;
        else
        {
            currentStage = stage.StageNumber;
            LoadStage(currentStage);
        }

    }    
    public void UpdateStageInfo()
    {
        GameManager.Instance.UpdateNumberOfStagesCleared();
        int number = GameManager.Instance.NumberOfStagesCleared;
        stages[number].IsOpen = true;
    }
    public void LoadStage(int number)
    {
        SceneManager.LoadScene($"Stage{number}");
    }
    public void BtnEvt_LoadStage(int number)
    {
        GameManager.Instance.SelectStage(number);
    }
    public void BtnEvt_LoadMain()
    {
        GameManager.Instance.LoadMainScene();
    }
}
