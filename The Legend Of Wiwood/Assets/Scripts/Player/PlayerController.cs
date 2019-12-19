using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed; //Player Movement Speed
    public float jumpForce; //Player Jump Height
    private float moveInput; //Stores Which key the player is pressing

    private Rigidbody2D rb; //Stores the players rigidbody 2d

    private bool facingRight = true; //The player sprite will flip dependign on this variables value


    private bool isGrounded; //Stores the info to see if the player is touching the ground
    public Transform groundCheck; //The position of the players feet
    public float checkRadius; //The Radius that the player checks to see if it is grounded
    public LayerMask whatIsGround; //Makes sure the player does not detect itself as ground


    private int extraJumps; //how many extra jumps
    public int extraJumpValue; //how many extra jumps the script resets itslef to after jumping

    public Transform tpPos1; //The position the player teleports to when colliding with a teleporter

    private void Start()
    {
        extraJumps = extraJumpValue; //Sets extrajumps to extrajumpsvalue
        rb = GetComponent<Rigidbody2D>(); //sets rb to the players rigidbody2d
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //detects if the player is on the ground



        moveInput = Input.GetAxis("Horizontal"); //sets move input to the coresponding key
        rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y); //moves player

        if (facingRight == false && moveInput > 0) //detects if the player is facing the wrong way if so call flip function
        {
            Flip();

        } else if(facingRight == true && moveInput < 0) //detects if the player is facing the wrong way if so call flip function
        {
            Flip();
        }
    }
    private void Update()
    {
        if (isGrounded == true) //If the player isgrounded it resets the players amount of jumps
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) //if the space bar is pressed the player jumps and removes 1 from extra jump value
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && isGrounded == true) //if the player is touching the ground when it jumps it does not remove 1 from extrajumps
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void Flip() //flips the player sprite
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Teleporter")) //teleports the player
        {
            transform.position = tpPos1.position;
        }

    }



}
