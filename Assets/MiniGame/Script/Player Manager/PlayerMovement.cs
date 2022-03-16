using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    #region -이동 / 점프 관련-
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody2D rigid;
    private bool left = false;
    private bool right = false;
    private bool jump = false;

    private float currentSpeed = 0f;
    private float jumpPower = 50.0f;
    private float moveSpeed = 5.0f;
  
    public bool Jump { get => jump; set => jump = value; }
    public bool Left { get => left; set => left = value; }
    public bool Right { get => right; set => right = value; }

    private float dashSpeed = 10.0f;
    private bool dash = false;
    public bool Dash { get => dash; set => dash = value; }
    #endregion


    #region - 필드 관련 -
    private RaycastHit2D hitForJump;
    private RaycastHit2D hitForField;
    private float distance = 1f;
    private int layerMask;

    private bool isOnIce = false;

    private bool isOnLow = false;
    public bool IsOnIce { get => isOnIce; set => isOnIce = value; }
    
    #endregion


    private Transform startPoint;
    private SpriteRenderer sprite;
    private Animator animator;
    private InGameManager inGameManager;
    public SpriteRenderer Sprite { get => sprite; set => sprite = value; }
    private void Awake()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        StartCoroutine(Co_FindStartPoint());
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        StartCoroutine(JumpDelay());
        
    }  
    private void FixedUpdate()
    {
        if (!inGameManager.IsClear)
        {
            if (left)
            {
                MoveToDirection(dash, Vector3.left);
            }
            if (right)
            {
                MoveToDirection(dash, Vector3.right);
            }
        } 
    }
    public void Update()
    {
        
        if (jump) transform.parent = null;

        #region /**테스트 코드**/
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!jump) JumpEvt();
        }
#endif
#endregion

        Debug.DrawRay(transform.position, -transform.up * distance, Color.green);
        hitForField = Physics2D.BoxCast(transform.position, transform.lossyScale, 0, -transform.up, distance, layerMask);
        if (hitForField.collider != null)
        {
            if(hitForField.collider.tag == "Ice")
            {
                isOnIce = true;
            }
            else
            {
                isOnIce = false;
            }
            if (hitForField.collider.tag == "LowSpeedFloor")
            {
                isOnLow = true;
            }
            else
            {
                isOnLow = false;
            }
            if (hitForField.collider.tag == "MoveFloor")
            {
                transform.parent = hitForField.collider.transform;
            }
            else
            {
                transform.parent = null;
            }
        }
        else
        {
            isOnIce = false;
            isOnLow = false;
        }
    }
    private void MoveToDirection(bool isDash, Vector3 direction)
    {
        if (!isDash)
        {
            moveDirection = direction;
            Move(moveSpeed);
        }
        else
        {
            moveDirection = direction;
            Move(dashSpeed);
        }

    }
    private void Move(float speed)
    {
        transform.position += isOnLow ? moveDirection * (speed / 3) * Time.deltaTime : moveDirection * speed * Time.deltaTime;
        currentSpeed = moveSpeed;
    }
    public void JumpEvt()
    {
        rigid.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        jump = true;
        animator.SetBool("isJump", jump);
        //JumpDelay();
    }
    IEnumerator JumpDelay()
    {
        while (true)
        {
            if (jump)
            {
                yield return new WaitForSeconds(0.1f);              
                Debug.DrawRay(transform.position, -transform.up * distance, Color.red);
                //hitForJump = Physics2D.Raycast(transform.position, -transform.up, distance, layerMask);
                hitForJump = Physics2D.BoxCast(transform.position, new Vector2(1.7f,1), 0, -transform.up, distance, layerMask);
                if (hitForJump.collider != null)
                {
                    if (hitForJump.collider.transform.tag == "Floor" || hitForJump.collider.transform.tag == "Ice" || hitForJump.collider.transform.tag == "MoveFloor" || hitForJump.collider.transform.tag == "LowSpeedFloor")
                    {
                        jump = false;
                        animator.SetBool("isJump", jump);
                    }
                    else
                    {
                        Debug.Log(hitForJump.collider.gameObject.name);
                    }
                }
            }
            yield return null;
        }         
    }
    public IEnumerator MoveOnIce()
    {
        float slideTime = 0f;
        while (slideTime < 0.5f)
        {
            slideTime += Time.deltaTime;
            transform.position += moveDirection * currentSpeed * Time.deltaTime;
            yield return null;
        }
    }
    public void OnDrawGizmos()
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.position, new Vector2(1.7f, 1), 0, -transform.up, distance,layerMask);
        Gizmos.color = Color.red;
        if(hit.transform != null)
        {
            Gizmos.DrawWireCube(transform.position + (-transform.up) * distance, new Vector2(1.7f,1));
            //Debug.Log(hit.transform.gameObject);
        }    
    }
    IEnumerator Co_FindStartPoint()
    {
        while (!startPoint)
        {
            startPoint = GameObject.Find("StartPoint").transform;
            yield return null;
        }
        transform.position = startPoint.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Clear")
        {
            inGameManager.IsClear = true;
            transform.position = collision.transform.position;
            Destroy(rigid);
            transform.DOScale(0, 2f);
            Invoke("ActiveClearPopUpForInvoke", 2f);
        }
    }
    private void ActiveClearPopUpForInvoke()
    {
        inGameManager.ActiveClearPopUp();
    }
}