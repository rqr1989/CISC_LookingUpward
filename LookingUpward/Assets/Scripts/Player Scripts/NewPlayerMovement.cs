using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    //refernce to player characters RigidBody2d component
    private Rigidbody2D body;
  
    // refernce to player animation
    private Animator playerAnim;

    //set player walk speed
    [SerializeField] public float speed;
    [SerializeField] public float Runspeed;
    [SerializeField] public float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    //reference to boxCollider 2D
    private BoxCollider2D box;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    private void Awake()
    {
        //playerInput = GetComponent<PlayerInput>();
        //get rigidBody2d 
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Runspeed = speed * 1.5f;
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    

        //flip player when moving left and right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
     
        

        //set animator pameter, if player is pressing right or left arrow, walk animation is true
        playerAnim.SetBool("walking", horizontalInput != 0);
        
        playerAnim.SetBool("grounded", isGrounded());
        //while R is pressed down player speed is set to Runspeed
        if(Input.GetKey(KeyCode.R))
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * Runspeed, body.velocity.y);

        }
        if (wallJumpCooldown > 0.2f)
        {
           
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

            if (onWall() && !isGrounded())// player is on a wall and not grounded
            {
                body.gravityScale = 0;//sets gravity to 0
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3; //sets player gravity back to noraml

            if (Input.GetKeyDown(KeyCode.Space))

                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }
        

    private void Jump()
    {
        if(isGrounded()) //if player is on the ground
        {
            SoundManager.instance.PlaySound(jumpSound);
            body.velocity = new Vector2(body.velocity.x, jumpPower);

            playerAnim.SetTrigger("jump"); //activates jump animation
        }
       //if onwall and not on the ground
         else if (onWall() && !isGrounded())
        {
            if(horizontalInput == 0) 
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            
            wallJumpCooldown = 0;
           
            
        }
    }
  

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
       
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);

        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        //player must be still, on ground and not on wall to attack
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
