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
    [SerializeField] public float speed = 10.0f;

    //reference to boxCollider 2D
    private BoxCollider2D box;

    [SerializeField]private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private PlayerInput playerInput;
    
    //sets Jump equal to 12
    public float Jumpheight = 12.0f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();


        //get rigidBody2d 
        body = GetComponent<Rigidbody2D>();

        playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

     

        //flip player when moving left and right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        
            Jump();
    
        

        //set animator pameter, if player is pressing right or left arrow, walk animation is true
        playerAnim.SetBool("walking", horizontalInput != 0);
        playerAnim.SetBool("grounded", isGrounded());

    }
        

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);

        playerAnim.SetTrigger("jump");
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
          
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

}
