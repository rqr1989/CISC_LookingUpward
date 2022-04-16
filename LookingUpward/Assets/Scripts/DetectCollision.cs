using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    int score = 0;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.gameObject.tag;

        if(tag == "pickup_health")
        {
            Destroy(collision.collider.gameObject);

            //calls addHealth method
            playerHealth.AddHealth();
        }

        else if (tag == "pickup_Madness")
        {
            Destroy(collision.collider.gameObject);

            //calls addHealth method
            playerHealth.AddMadness();

        }
        //if player collides with object with pick_up tag
        else if (tag == "pick_up")
        {
            Destroy(collision.collider.gameObject);

            score += 1; //add 1 to score

        }
    }

}
