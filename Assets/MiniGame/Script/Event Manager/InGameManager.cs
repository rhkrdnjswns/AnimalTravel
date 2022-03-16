using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private GameObject clearPopUp;
    private bool isClear = false;
    public bool IsClear { get => isClear; set => isClear = value; }
    private void Start()
    {
        isClear = false;
    }
    public void ActiveClearPopUp()
    {
        clearPopUp.SetActive(true);
        //StageManager.Instance.UpdateStageInfo();
    }
}
