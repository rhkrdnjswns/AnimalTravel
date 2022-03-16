using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravtiy : MonoBehaviour
{
    [Range(0.1f, 2.0f)] // 괄호 안 값 변경해서 min~max 조절 가능 (수치가 낮을수록 낮은 중력 영향) 
    [SerializeField] private float gravityValue = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = gravityValue;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}
