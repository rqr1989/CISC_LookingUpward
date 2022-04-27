using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkPointSound;
    [SerializeField] private GameObject currentCheckpoint;
    private HealthSystem playerhealth;

    private void Awake()
    {
        playerhealth = GetComponent<HealthSystem>();
    }


    public void Respawn()
    {
        transform.position = currentCheckpoint.transform.position; //move player to current checkpoint

        //restore player health and reset aanimation
        playerhealth.Respawn(); //call reswpan method from HealthSystem script


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
