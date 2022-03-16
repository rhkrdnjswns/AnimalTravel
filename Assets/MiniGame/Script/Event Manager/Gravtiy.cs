using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravtiy : MonoBehaviour
{
    [Range(0.1f, 2.0f)] // ��ȣ �� �� �����ؼ� min~max ���� ���� (��ġ�� �������� ���� �߷� ����) 
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
