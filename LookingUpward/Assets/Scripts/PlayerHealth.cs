using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 3;
    public int madness = 4;
   
    void HealthDown()
    {
        health -= 1;
        if(health <=0)
        {
            //pause game

            //activate Game Over Menu

            //activate text that says "You died, try not to do that"
        }

    }
   void MadnessDown()
    {
        madness -= 1;
        if (madness <= 0)
        {
            //pause game

            //activate Game Over Menu

            //Activate text that says "Sanity doesnt suit you."
        }


     

    }
    void AddMadness()
    {
        if (madness <= 3)
        {
            madness += 1;
        }


    }

    void AddHealth()
    {
        if (health <= 2)
        {
            health += 1;
        }
    }
}
