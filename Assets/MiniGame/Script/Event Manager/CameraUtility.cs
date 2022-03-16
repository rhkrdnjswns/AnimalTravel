using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtility : MonoBehaviour
{
    private Transform playerTr;
    [Header("카메라가 고정되는 X축 위치(leftMax는 음수로 설정)")]
    [SerializeField] private float leftMax;
    [SerializeField] private float rightMax;
    private GameObject darkScreen;
    [SerializeField] private float cameraOffset;
    [SerializeField] private float cameraUtill;
    private InGameManager inGameManager;
    private Transform clearPoint;
    private void Awake()
    {
        clearPoint = FindObjectOfType<ClearPoint>().transform;
        inGameManager = FindObjectOfType<InGameManager>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        darkScreen = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        if(GameManager.Instance != null)
        {
            if (GameManager.Instance.CurrentStage == 9)
            {
                rightMax = 75f;
            }
        }
       
       
    }
    // Update is called once per frame
    void Update()
    {
        if (inGameManager.IsClear)
        {
            transform.parent = null;
            Vector3 target = new Vector3(clearPoint.position.x, clearPoint.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, 5 * Time.deltaTime);
            return;
        }
        if(playerTr.position.x < leftMax)
        {
            transform.parent = null;
            Vector3 target = new Vector3(leftMax, playerTr.position.y + cameraUtill, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target,10 * Time.deltaTime);
        }
        else if(playerTr.position.x > rightMax)
        {
            transform.parent = null;
            Vector3 target = new Vector3(rightMax, playerTr.position.y + cameraUtill, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, 10 * Time.deltaTime);
        }
        else if(playerTr.position.x >= leftMax && playerTr.position.x <= rightMax)
        {
            transform.parent = playerTr;
            Vector3 target = new Vector3(0, cameraOffset, -10);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, 10 * Time.deltaTime);           
        }      

        if (Input.GetKeyDown(KeyCode.U))
        {
            darkScreen.SetActive(darkScreen.activeSelf == true ? false : true);
            
        }
    }
    
}
