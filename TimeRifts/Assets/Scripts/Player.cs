using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    private Rigidbody2D rb;

    private bool isGrounded = true;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jumping();
        }
    }

    void Movement()
    {
        float directionX;
        directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
    }

    void Jumping()
    {
        Vector2 jumpForce = new Vector2(rb.velocity.x, jumpSpeed);
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
