using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform startPortal;

    [SerializeField] private Transform endPortal;

    [SerializeField]

    private void onTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           // if(collision.transform.position.x < transform)
        }
    }
}
