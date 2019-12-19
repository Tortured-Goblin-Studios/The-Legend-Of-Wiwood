using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public bool movingRight;

    public float moveInput =1;

    public Transform tpPos1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movingRight == true)
        {
            moveInput *= 1;
        }
        else
        {
            moveInput *= -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y); //moves player
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Teleporter"))
        {
            transform.position = tpPos1.position;
        }

    }


}
