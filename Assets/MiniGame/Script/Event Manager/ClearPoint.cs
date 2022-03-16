using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    private InGameManager inGameManager;

    private void Awake()
    {
        inGameManager = FindObjectOfType<InGameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("플레이어 충돌");
            Invoke("ActiveClearPopUpForInvoke", 2f);
        }
    }
    private void ActiveClearPopUpForInvoke()
    {
        if(inGameManager!=null)
        inGameManager.ActiveClearPopUp();
    }
}
