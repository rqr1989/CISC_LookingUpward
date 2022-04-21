using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
   public int score = 0;
    public int currentscore;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.gameObject.tag;
        //if player collides with an object that has the tag pickup_health
        if(tag == "pickup_health")
        {
            //object destroyed upon collision
            Destroy(collision.collider.gameObject);

            //calls addHealth method and adds 1 to player health is below the upper limit
           // NewplayerHealth.AddHealth();
        }

        else if (tag == "pickup_Madness") // if player collides with object with the pickup_Madness tag
        {
            Destroy(collision.collider.gameObject); //destroys object

            //add 1 to madness if below the upper limit
         //   playerHealth.AddMadness();
        // HealthSystem.

        }
        //if player collides with object with pick_up tag
        else if (tag == "pick_up")
        {
            Destroy(collision.collider.gameObject);// destorys object

            score += 1; //add 1 to score

        }
    }
    public void CurrentScore()
    {
        score = currentscore;
    }

}
