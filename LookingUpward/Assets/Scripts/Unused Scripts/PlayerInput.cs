using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //handles sneak, melee attack and magic attack and 
    private float time = .1f;
    private const string HORIZONTAL_INPUT = "Horizontal";
   
    private const string CAMERA_HORIZONTAL = "CameraHorizontal";
    private bool sneak = false;
    // refernce to player attack animation
    private Animator playerAttackAnimate;

    //reference to player magic attack animation
    private Animator playerMagicAnimate;

  

    // Update is called once per frame
    void Update()
    {
        //
        //if leftShift is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
         //change to attack animation

            //check if player connnects to enemy colloder
           // if(hit != null )
            {
                //if enemy is hit -1 from enemy health 
            }
        }

        //if M is pressed 
        if(Input.GetKeyDown(KeyCode.M))
        {
            //change to magic casting animation
            //check if projectile hits  enemy colloder

            //if enemey is hit stuns enemy for 3 seconds

            
             
        }
        //if L is pressed, activate sneak mode
        if(Input.GetKeyDown(KeyCode.L))
        {
            //set sneak to true
            sneak = true;
            //cause sprite to be semi transparent for several seconds

            //enenmies ignore player while in stealth mode

            //Invoke MadnnesDown method to subtract 1 madness
            Invoke("MadnessDown", time);


        }
    }
}
