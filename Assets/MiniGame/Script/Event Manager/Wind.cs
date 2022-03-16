using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isWind = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("호호");
            isWind = true;
            StartCoroutine(StartWind(collision.transform));
            //collision.transform.position += isLeft ? collision.transform.right * 2 * Time.deltaTime : -collision.transform.right * 2 * Time.deltaTime; 
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isWind = false;
        }
    }
    IEnumerator StartWind(Transform obj)
    {
        while (isWind)
        {
            Debug.Log("코루틴");
            obj.transform.position += isLeft ? obj.right * 2 * Time.deltaTime : -obj.right * 2 * Time.deltaTime;
            Debug.Log(Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}
