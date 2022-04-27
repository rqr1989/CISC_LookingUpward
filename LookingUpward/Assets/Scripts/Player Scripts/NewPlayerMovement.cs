using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    //refernce to player characters RigidBody2d component
    private Rigidbody2D body;
  
    // refernce to player animation
    private Animator playerAnim;
    [Header("Player Movement")]
    //set player walk speed
    [SerializeField] public float speed;
    [SerializeField] public float Runspeed;
    [SerializeField] public float jumpPower;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;


    [Header("Other")]
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


        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //adjust jump height
        if(Input.GetKeyUp(KeyCode.Space) && body.velocity.y >0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }

        if(onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }

        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

        //while R is pressed down player speed is set to Runspeed
       /** if(Input.GetKey(KeyCode.R))
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * Runspeed, body.velocity.y);

        } **/
      
    }
        

    private void Jump()
    {
        if(!onWall() && jumpCounter <=0) //if player is on the ground
        {
          
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            SoundManager.instance.PlaySound(jumpSound);
            //  playerAnim.SetTrigger("jump"); //activates jump animation
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
