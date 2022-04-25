using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{   [Header("Health")] 
    [SerializeField] private float startingMadness;

    public float currentMadness { get; private set; }
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim; //reference to animator

    private bool dead;

    [Header("iFrames")]

    [SerializeField] private float invincibleDur;

    [SerializeField] private int numberOfFlashes;

    private SpriteRenderer spriteRend;
    private GameOver gameover;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth; //set startingHealth equal to currentHealth
        currentMadness = startingMadness; //

        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    
   public void TakeDamage(float damageTaken)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, startingHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");

            StartCoroutine(Invuneribility());
        }
        else
        {
            if(!dead)
            {
                //player dead
                anim.SetTrigger("Die");
                //diable player movement
                GetComponent<NewPlayerMovement>().enabled = false;
                dead = true;


              /**  if (dead == true)
                {
                    gameover.TurnOnGameOver();
                }**/
            }
          
        }
    }
    public void TakeMadnessDamage(float damageTaken)
    {
        currentMadness = Mathf.Clamp(currentMadness - damageTaken, 0, startingMadness);

        if (currentMadness > 0)
        {
            StartCoroutine(Invuneribility());
        }
        else
        {
            if (!dead)
            {
                //player dead
                anim.SetTrigger("Die");

                if (GetComponent<NewPlayerMovement>() != null)
                    GetComponent<NewPlayerMovement>().enabled = false;
                dead = true;
            }


        }
    }
   public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void AddMadness(float _value)
    {
        currentMadness= Mathf.Clamp(currentMadness + _value, 0, startingMadness);
    }

    private IEnumerator Invuneribility()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true); //ignore collisions with onjects on layer 11(enemies)
                                                     
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 1, 0, 0.5f); 
            yield return new WaitForSeconds(invincibleDur / (numberOfFlashes * 2)); //wait 1 second
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invincibleDur / (numberOfFlashes * 2));
        }
        
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }


    // if player falls, respawn at respwan point and lose a life




}
