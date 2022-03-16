using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    public Animator animator;//애니메이터 추가
    public float count = 2.0f;
    public GameObject Block;
    private GameObject Floor;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Block.SetActive(false);
        }
        if (Block.activeSelf == false)
        {
            Invoke("BlockSpawn", 5f);
        }
    }
    public void BlockSpawn()
    {
        Block.SetActive(true);
    }
}
