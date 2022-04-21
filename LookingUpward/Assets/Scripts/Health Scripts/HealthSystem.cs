using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float startingMadness;
    public float currentMadness { get; private set; }
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim;

    private bool dead;
    // Start is called before the first frame update
   private void Awake()
    {
        currentHealth = startingHealth;
            currentMadness = startingMadness;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   public void TakeDamage(float damageTaken)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, startingHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //player hurt
        }
        else
        {
            if(!dead)
            {
                //player dead
                anim.SetTrigger("Die");
                GetComponentInChildren<NewPlayerMovement>().enabled = false;
                dead = true;
            }
          
            
        }
    }
    public void TakeMadnessDamage(float damageTaken)
    {
        currentMadness = Mathf.Clamp(currentMadness - damageTaken, 0, startingMadness);

        if (currentMadness > 0)
        {
            //player hurt
        }
        else
        {
            if (!dead)
            {
                //player dead
                anim.SetTrigger("Die");
                GetComponentInChildren<NewPlayerMovement>().enabled = false;
                dead = true;
            }


        }
    }
    private void Update()
    {
       
    }
}
