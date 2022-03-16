using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Debug.Log(playerMovement.Jump);
            playerMovement.Jump = false;
        }
    }
   
}
