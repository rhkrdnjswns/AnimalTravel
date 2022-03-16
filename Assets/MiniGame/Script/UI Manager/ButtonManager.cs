using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator playerAnim;
    #region -대쉬 관련-
    private float clickInterval = 0.3f;
    private float lastClickTimeLeft;
    private float lastClickTimeRight;
    #endregion
    [SerializeField] private string currentScene;
    [SerializeField] private GameObject setting;
    private bool isReady = false;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerAnim = playerMovement.GetComponent<Animator>();
        currentScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 2).name;
        StartCoroutine(Co_IsReady());
    }
    public void BtnEvt_Left(bool isTrue)
    {
        if (!isReady) return;
        playerMovement.Sprite.flipX = true;
        playerMovement.Left = isTrue;
        SetAnimParametersIsWalkAndIsRun(playerMovement.Left, false);
    }
    public void BtnEvt_Right(bool isTrue)
    {
        if (!isReady) return;
        playerMovement.Sprite.flipX = false;
        playerMovement.Right = isTrue;
        SetAnimParametersIsWalkAndIsRun(playerMovement.Right, false);
    }
    public void BtnEvt_DashLeft()
    {
        if (!isReady) return;
        float timeSinceLastClick = Time.time - lastClickTimeLeft;
        if(timeSinceLastClick <= clickInterval)
        {
            Debug.Log("Double Click");
            playerMovement.Dash = true;
            SetAnimParametersIsWalkAndIsRun(false, true);
        }
        else
        {
            Debug.Log("Normal Click");
            playerMovement.Dash = false;
            //SetAnimParametersIsWalkAndIsRun(true, false);
        }
        lastClickTimeLeft = Time.time;
    }
    public void BtnEvt_DashRight()
    {
        if (!isReady) return;
        float timeSinceLastClick = Time.time - lastClickTimeRight;
        if (timeSinceLastClick <= clickInterval)
        {
            Debug.Log("Double Click");
            playerMovement.Dash = true;
            SetAnimParametersIsWalkAndIsRun(false, true);
        }
        else
        {
            Debug.Log("Normal Click");
            playerMovement.Dash = false;
           // SetAnimParametersIsWalkAndIsRun(true, false);
        }
        lastClickTimeRight = Time.time;
    }
    public void BtnEvt_Jump()
    {
        if (!isReady) return;
        if (!playerMovement.Jump)
        {
            playerMovement.JumpEvt();
        }
    }
    public void BtnEvt_MoveOnIce()
    {
        if (!isReady) return;
        if (playerMovement.IsOnIce)
        {
            StartCoroutine(playerMovement.MoveOnIce());
        }
    }
    public void BtnEvt_Retry()
    {
        GameManager.Instance.SelectStage(GameManager.Instance.CurrentStage);
       // GameManager.Instance.ReloadScene(gameObject.scene.name);
    }
    public void BtnEvt_ExitStage()
    {
        GameManager.Instance.LoadStageSelectScene();
    }
    public void BtnEvt_Setting(bool isOpen)
    {
        if (!isReady) return;
        setting.SetActive(isOpen);
    }
    public void BtnEvt_NextStage()
    {
        switch (currentScene)
        {
            case "Game1":
                GameManager.Instance.SelectStage(3);
                break;
            case "Game3":
                GameManager.Instance.SelectStage(9);
                break;
            case "Game9":
                GameManager.Instance.SelectStage(25);
                break;
            case "Game25":
                GameManager.Instance.SelectStage(30);
                break;
            case "Game30":
                GameManager.Instance.SelectStage(45);
                break;
            default:
                GameManager.Instance.LoadStageSelectScene();
                break;
        }
       
    }
    private void SetAnimParametersIsWalkAndIsRun(bool isWalk, bool isRun)
    {
        playerAnim.SetBool("isWalk", isWalk);
        playerAnim.SetBool("isRun", isRun);
    }
    private IEnumerator Co_IsReady()
    {
        yield return new WaitForSeconds(1.5f);
        isReady = true;
    }

}
