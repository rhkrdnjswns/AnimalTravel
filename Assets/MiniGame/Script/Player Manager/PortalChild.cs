using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalChild : MonoBehaviour
{
    private enum Number { A, B}
    [SerializeField] private Number number;
    private Portal portal;
    private void Start()
    {
        portal = GetComponentInParent<Portal>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           
            if(number == Number.A)
            {
                portal.IsA = true;
            }
            else
            {
                portal.IsA = false;
            }
            portal.Teleportation(collision.transform);
        }
    }
}
