using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Range Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] bloodProjectiles;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D box;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip enemyMagicSound;

    private Animator anim;
    private EnemyPatrol enemypatrol;
    private void Awake()
    {
        enemypatrol = GetComponentInParent<EnemyPatrol>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        // if player is within sight of the enemy
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;

                anim.SetTrigger("magicAttack");  //attack
                SoundManager.instance.PlaySound(enemyMagicSound);

            }
        }
        //disables patrol when player is in sight
        if (enemypatrol != null)
        {
            enemypatrol.enabled = !PlayerInSight();
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(box.bounds.size.x * range, box.bounds.size.y, box.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

   
        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box.bounds.center + transform.right * range * transform.localScale.x, new Vector3(box.bounds.size.x * range, box.bounds.size.y, box.bounds.size.z));
    }
    private void RangedAttack()
    {
        
        cooldownTimer = 0;
        //find and shoot projectile
        bloodProjectiles[FindBloodProjectile()].transform.position = firepoint.position;
       bloodProjectiles[FindBloodProjectile()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }
    private int FindBloodProjectile()
    {
        for(int i = 0; i< bloodProjectiles.Length; i++)
        {
            if (!bloodProjectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
