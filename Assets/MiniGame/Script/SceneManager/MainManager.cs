using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private void Start()
    {
        //SoundManager.Instance.PlayAudio();
    }
    public void BtnEvt_LoadStageSelect()
    {
        GameManager.Instance.LoadStageSelectScene();
    }
}
