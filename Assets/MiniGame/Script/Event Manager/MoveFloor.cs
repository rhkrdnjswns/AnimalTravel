using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private Transform moveFloor;
    private Transform Apoint;
    private Transform Bpoint;

    [SerializeField] private Transform nextPoint;

    [Header("발판 이동속도")]
    [SerializeField] private float speed;
    [Header("발판 대기시간")]
    [SerializeField] private float second;
  
    // Start is called before the first frame update
    void Start()
    {
        moveFloor = transform.GetChild(0).GetComponent<Transform>();
        Apoint = transform.GetChild(1).GetComponent<Transform>();
        Bpoint = transform.GetChild(2).GetComponent<Transform>();
        nextPoint = Apoint;
        StartCoroutine(MovingWalker());
    }
    private void Update()
    {
        moveFloor.position = Vector3.MoveTowards(moveFloor.position, nextPoint.position, speed * Time.deltaTime);     
    }
    IEnumerator MovingWalker()
    {     
        while (true)
        {
            if(moveFloor.position == Apoint.position)
            {
                yield return new WaitForSeconds(second);
                nextPoint = Bpoint;
            }
            else if(moveFloor.position == Bpoint.position)
            {
                yield return new WaitForSeconds(second);
                nextPoint = Apoint;
            }
            yield return null;
        }
    }
}
