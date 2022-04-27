using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] magicProjectiles;
    [SerializeField] private AudioClip magicSound;
    [SerializeField] private AudioClip attackSound;

    private Animator anim;
    private NewPlayerMovement newplayerMovement;
    private float cooldownTimer = Mathf.Infinity;
     private void Awake()
    {
        anim = GetComponent<Animator>();
       newplayerMovement  = GetComponent<NewPlayerMovement>();
    }

    private void Update()
    {
        //if player presses mouse button calls Magic Attack method
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && newplayerMovement.canAttack())
            MagicAttack();
        
        cooldownTimer += Time.deltaTime;
        // if player presses either shift key, calls MeleeAttack method
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer > attackCooldown && newplayerMovement.canAttack())
            MeleeAttack();
    }
    //triggers magic animation, access magic projectiles list and activates a projectile starting at the firePoint
    private void MagicAttack()
    {
        SoundManager.instance.PlaySound(magicSound);
        anim.SetTrigger("magic");
        cooldownTimer = 0;

        //make sure projectile fires in curret direction
        magicProjectiles[FindMagicProjectile()].transform.position = firePoint.position;
        magicProjectiles[FindMagicProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        //pool magic projectiles

        //if magic projectile collides with object with the tag enemy, enemy should be damaged/ destroyed
    }
    private void MeleeAttack()
    {
        SoundManager.instance.PlaySound(attackSound);
        anim.SetTrigger("attack");

        //if magic projectile collides with object with the tag enemy, enemy should be damaged/ destroyed
    }

    private int FindMagicProjectile()
    {
        for(int i =0; i< magicProjectiles.Length; i++)
        {
            if (!magicProjectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
