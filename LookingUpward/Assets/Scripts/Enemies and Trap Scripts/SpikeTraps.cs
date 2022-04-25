using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    [SerializeField] public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if spikes collide with player
        if (collision.tag == "Player")
        {
            //subtracts 1 health from player
            collision.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }
}