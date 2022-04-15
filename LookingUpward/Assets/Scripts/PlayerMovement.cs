using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
  
{
    private float jumpHeaight;
    private float terminalVelocity = 1000;
    private float gravity;
    private float gravityComponent;

    private PlayerInput playerInput;
        private CharacterController characterController;
    private Animator animator;

    //set player walk speed
    public float speed = 200.0f;

    //set player run speed
    public float runSpeed = 300.0f;

    //refernce to player characters RigidBody2d component
    private Rigidbody2D body;

    // refernce to player animation
    private Animator playerAnimate;
    //reference to boxCollider 2D
    private BoxCollider2D box;

    //sets Jump equal to 12
    public float Jump = 12.0f;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        //get rigidBody2d 
        body = GetComponent<Rigidbody2D>();

        //get player animation
        playerAnimate = GetComponent<Animator>();

        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;


        //prevents player from jumping in midair

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(max.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
       
        //creates bool grounded and setes it to false
        bool grounded = false;
       
        //if a collider is underneath the player
        if(hit != null)
        {//player is on solid ground
            grounded = true;
        }
        //checks that player is on grounded and not moving 
        body.gravityScale = grounded && deltaX == 0 ? 0 : 1;

        //if space key is pressed down
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //makes player jump upwards multiplied by the value of Jump
            body.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
        }
        //check if player is on a moving platform
        MovingPlatforms platform = null;


        if(hit!=null)
        {
            platform = hit.GetComponent<MovingPlatforms>();
        }
        //if player is on a moving platform
        if (platform !=null)
        {
            //set players transform to move with the platform
            transform.parent = platform.transform;
        }
        //else
        else
        {//set transfor.parent to null
            transform.parent = null;
        }
        //if the player is holding down the R key
        if(Input.GetKey(KeyCode.R))
            {
            //speed is set to runSpeed
            speed = runSpeed;
           /**deltaX = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
             movement = new Vector2(deltaX, body.velocity.y);
            body.velocity = movement; **/
        }
        playerAnimate.SetFloat("speed", Mathf.Abs(deltaX));
       
        //fixes player scale
        Vector3 playerScale = Vector3.one;

        if(platform!= null) //if player is on a moving platform
        {
            playerScale = platform.transform.localScale;
        }
        if(deltaX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX) / playerScale.x, 1 / playerScale.y, 1);
        }
        //if deltaX and 0 are not approximately equal
        if(!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
        //add Wall Jump
         void wallJump()
    {
            //is  collider against player on either side and player is in midair
            //player can  press space to jump using the wall 



        }
}
  
}
