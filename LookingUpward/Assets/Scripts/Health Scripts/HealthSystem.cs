using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{   [Header("Health")] 
    [SerializeField] private float startingMadness;

    private GameOver gameOver;
    private DetectCollision detectcollision;
    public float currentMadness { get; private set; }
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim; //reference to animator

    private bool dead;
    public int score;

    [Header("iFrames")]

    [SerializeField] private float invincibleDur;

    [SerializeField] private int numberOfFlashes;

    private SpriteRenderer spriteRend;
    private GameOver gameover;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [Header("Hurt Sound")]
    [SerializeField] private AudioClip hurtSound;
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
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if(!dead)
            {

                //deactivate attacjed components
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }


                //player dead
                anim.SetBool("grounded", true);
                anim.SetTrigger("Die");
                dead = true;
                SoundManager.instance.PlaySound(deathSound);


            }
          
        }
        if(dead)
        {
            score = detectcollision.CurrentScore();//set score equal to current score
            gameOver.TurnOnGameOver(score);//turn on game ovber menu and pass score
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
                //deactivate attacjed components
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }


                //player dead
                anim.SetBool("grounded", true);
                anim.SetTrigger("Die");
                dead = true;
                SoundManager.instance.PlaySound(deathSound);

            }
            }
        if (dead)
        {
            score = detectcollision.CurrentScore();//set score equal to current score
            gameOver.TurnOnGameOver(score);//turn on game ovber menu and pass score
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
   public void Respawn()
    {
        dead = false;
        //AddHealth(startingHealth);
        anim.ResetTrigger("Die");
        anim.Play("Idle");
        StartCoroutine(Invuneribility());
        //Activate attacjed components
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }

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


}
