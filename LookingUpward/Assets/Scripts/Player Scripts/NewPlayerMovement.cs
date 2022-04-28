using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    //refernce to player characters RigidBody2d component
    private Rigidbody2D body;
   // public GameObject LevelComplete;
    //private WinFlag winflag;

    // refernce to player animation
    private Animator playerAnim;
    [Header("Player Movement")]
    //set player walk speed
    [SerializeField] public float speed; //player speed

    [SerializeField] public float jumpPower;
    private HealthSystem playerhealth;
    [SerializeField] public GameObject fallpoint;
    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; // how long player can be off the ground before jumping
    private float coyoteCounter; //time passed

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps; //for double jumps
    private int jumpCounter; //number of jumps

    [Header("Wall Jump")]
    [SerializeField] float wallJumpx; //left and right
    [SerializeField] float wallJumpy; //vertical height
    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer; //layer mask for the ground
    [SerializeField] private LayerMask wallLayer; //layer mask for walls

    [Header("Portal")]
    [SerializeField] GameObject portalA;
    [SerializeField] GameObject portalB;
    private Animator portalAnim;
  [Header("Other")]
    //reference to boxCollider 2D
    private BoxCollider2D box;
 //   [SerializeField] public GameObject winCondition; //player speed
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip winSound;
    private void Awake()
    {
        //playerInput = GetComponent<PlayerInput>();
        //get rigidBody2d , animator, boxcollider2d
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        portalAnim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.R))//while player holds down R
        {
            speed = 15;//speed eqauls 10
            playerAnim.SetBool("running", true); //sets running to true
        }
        else
        {
            speed = 10f;//sets speed to 5
            playerAnim.SetBool("running", false);//sets running to false
        }

        //flip player when moving left and right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        //set animator pameter, if player is pressing right or left arrow, walk animation is true
        playerAnim.SetBool("walking", horizontalInput != 0);

        playerAnim.SetBool("grounded", isGrounded());

        //if space is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); //call jump method
        }
        //adjust jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }
        //if player is onWall
        if (onWall())
        {
            body.gravityScale = 0; //set gravity to 0
            body.velocity = Vector2.zero; //set velocity to zero
        }

        else
        {
            body.gravityScale = 7; //sets player gravity and velocity
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime; //resets cyote counter
                jumpCounter = extraJumps; //reset jumpCounter
            }
            else
            {
                //coyote counter begins to count down
                coyoteCounter -= Time.deltaTime;
            }
        }
        falling(); //call falling method
       
    
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WinLevel")
        {
            SoundManager.instance.PlaySound(winSound);     //play win sound
            collision.GetComponent<WinFlag>().winGame();   //show win dialouge

        }
        if (collision.tag == "Level1Complete")
            SoundManager.instance.PlaySound(winSound);     //play win sound
        collision.GetComponent<GameManager>().LoadGameScene();   //show win dialouge

    }
    //Jump Method
    private void Jump()
    {
        if (coyoteCounter < 0 && !onWall() && jumpCounter <=0) return; //if coyote counter is 0 and player not on wall and no extra jumps
        SoundManager.instance.PlaySound(jumpSound);
        //if player onWall
        if (onWall())
        {
            WallJump();//do a wall jump
        }
         else
            if(isGrounded()) //esle if grounded perform a regular jump
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        else
        //if player is grounded and the coyote counter is greater than zero
            if(coyoteCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        else
        {
            if(jumpCounter > 0)

            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                jumpCounter--;
            }
        }
        
        
        coyoteCounter = 0; //reset counter to 0 to stop from double jumping



    }
    private void WallJump() //wall jump method
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpx, wallJumpy));
        wallJumpCooldown = 0; // set to 0
    }

    private void falling() //falling method
    {
        if (body.transform.localScale.y < fallpoint.transform.localScale.y)
        {
            playerhealth.TakeDamage(1);
            playerhealth.Respawn();
        }

}
private bool isGrounded() //determines if player is on ground
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
       
        return raycastHit.collider != null;
    }

    private bool onWall()//determines whether player is on wall
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);

        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        //player must be still, on ground and not on wall to attack
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
    private void Portal()
    {

        //if player is at portalA and presses X, player is transported to portal b
  if (body.transform.position == portalA.transform.position && Input.GetKeyDown(KeyCode.X))
  {
      body.transform.position = portalB.transform.position;
        //portalAnim.Set
  }

 //if  player is at potalB and presses X, player is transported to portal A
    if  (body.transform.position == portalB.transform.position && Input.GetKeyDown(KeyCode.X))
      {
      body.transform.position = portalB.transform.position;
       
}
}
}
