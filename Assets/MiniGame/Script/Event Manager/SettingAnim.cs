using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingAnim : MonoBehaviour
{
    private void OnEnable()
    {
       
        transform.DOScale(1, 0.5f);
        transform.DOScale(0.8f, 0.5f).SetDelay(0.5f);
        
    }
    private void OnDisable()
    {       
        transform.localScale = new Vector3(0, 0, 1);
    }
}
