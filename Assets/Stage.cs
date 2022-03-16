using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage : MonoBehaviour
{
    private bool isOpen = false;
    public bool IsOpen { get => isOpen; set => isOpen = value; }
    public int StageNumber { get => stageNumber; }

    [SerializeField] private int stageNumber;

    private Text stageTxt;

    private void Awake()
    {
        //LoadStageInfo();
    }
    void Start()
    {       
        stageTxt = GetComponentInChildren<Text>();

        stageNumber = transform.GetSiblingIndex() + 1;

        if(stageNumber-1 <= GameManager.Instance.NumberOfStagesCleared)
        {
            isOpen = true;
        }
        if (!isOpen)
        {
            stageTxt.text = "Àá±è";
        }
        else
        {
            stageTxt.text = stageNumber.ToString();
        }
    }

    public void BtnEvt_SelectStage()
    {
        StageManager.Instance.SelectStage(this);
    }
    public void SaveStageInfo()
    {
        PlayerPrefs.SetString($"OPEN{stageNumber}", isOpen.ToString());
    }
    public void LoadStageInfo()
    {
        string value = PlayerPrefs.GetString($"OPEN{stageNumber}", "false");
        isOpen = System.Convert.ToBoolean(value);
    }
}
