using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthUI healthUI;
    public int health = 3;
    public int madness = 4;
    private void Awake()
    {
        healthUI = GetComponent<HealthUI>();
    }

    private void Update()
    {
        //if health is equal to3
        if(health == 3)
        {
            //all 3 health bar images are active
            healthUI.PlayerHealthToFull();
        }
      else  if (health == 2)
        {
            healthUI.PlayerHealthToTwo();
        }
        else if(health == 1)
        {
            healthUI.PlayerHealthToOne();
        }
        else if (health <= 0)
        {

        }
    }
    public void HealthDown()
    {

        health -= 1;
       
      

    }
   public void MadnessDown()
    {
        madness -= 1;
        if (madness <= 0)
        {
            //pause game

            //activate Game Over Menu

            //Activate text that says "Sanity doesnt suit you."
        }


     

    }
    public void AddMadness()
    {
        if (madness <= 3)
        {
            madness += 1;
        }


    }

   public void AddHealth()
    {
        if (health <= 2)
        {
            health += 1;
        }
    }

    public void GameOver()
    {


        if (health <= 0 || health <=0 && madness <=0)
        {
            //pause game

            //activate Game Over Menu

            //activate text that says "You died, try not to do that"
        }

        else if(madness <=0)
        {

        }
    }
}
