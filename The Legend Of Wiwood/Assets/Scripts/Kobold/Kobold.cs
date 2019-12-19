using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobold : MonoBehaviour
{

    public float speed; //Kobold Movement Speed
    public float jumpForce; //Kobold Jump Height
    [Range(-1, 1)]
    public float moveInput; //Stores Which way the player is to the Kobold

    private Rigidbody2D rb; //Stores the kobolds rigidbody 2d

    private bool facingRight = true; //The kobold sprite will flip dependign on this variables value

    public float attackRadius;
    private bool attack;
    public LayerMask playerLayer;

    private Animator koboldAnim;

    public GameObject koboldSpear;

    public Transform spearSpawn;

    public float attackSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //sets rb to the kobolds rigidbody2d
        koboldAnim = GetComponent<Animator>();
        StartCoroutine("Attack");
    }

    private void FixedUpdate()
    {
        attack = Physics2D.OverlapCircle(transform.position, attackRadius, playerLayer);

        if (attack == true)
        {
            koboldAnim.SetBool("isWalking", true);
        }
        else
        {
            koboldAnim.SetBool("isWalking", false);

        }

        rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y); //moves player

        if (facingRight == false && moveInput > 0) //detects if the player is facing the wrong way if so call flip function
        {
            Flip();

        }
        else if (facingRight == true && moveInput < 0) //detects if the player is facing the wrong way if so call flip function
        {
            Flip();
        }
    }
    private void Update()
    {



        //  rb.velocity = Vector2.up * jumpForce; JUMP

    }
    void Flip() //flips the player sprite
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    IEnumerator Attack()
    {
        Instantiate(koboldSpear, spearSpawn.position, spearSpawn.rotation);
        yield return new WaitForSeconds(attackSpeed);
        StartCoroutine("Attack");
    }

}
