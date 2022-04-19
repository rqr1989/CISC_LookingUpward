using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] magicProjectiles;
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
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && newplayerMovement.canAttack())
            Attack();
        
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //make sure projectile fires in curret direction
        magicProjectiles[FindMagicProjectile()].transform.position = firePoint.position;
        magicProjectiles[FindMagicProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        //pool magic projectiles
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
