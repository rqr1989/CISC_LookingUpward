using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim; //reference to animator

    private bool dead;

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
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth; //set startingHealth equal to currentHealth
        

        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float damageTaken)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
           
            StartCoroutine(Invuneribility());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
              
                anim.SetTrigger("Die");

           
               //deactivate attacjed components
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }


                dead = true;
                    SoundManager.instance.PlaySound(deathSound);
               
            }

        }
    }
   
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
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


   private void Deactivate()
    { gameObject.SetActive(false); }
       


}
