using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject camera;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool locationState = false; //false - location 1, true - location 2  !!!!!!!!!!!!!!!REFACTORING REQUIERED!!!!!!!!!!!!!!!!




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
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        else if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (SceneManager.GetActiveScene().buildIndex == PlayerPrefs.GetInt("currentLevel") + 1)
            {
                PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
            }
        }

        else if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Restart level
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ladder" && Input.GetKey(KeyCode.W))
        {
            Debug.Log("Ladder");
            rb.velocity = new Vector2(0,8);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ChangeLocationTrigger" && !locationState)
        {
            camera.transform.position -= new Vector3(0, 10.3f, 0);
            locationState = !locationState;
            collision.gameObject.transform.position = new Vector3(10.4f, -4.6f, -345.9f);

        }
        else if (collision.gameObject.tag == "ChangeLocationTrigger" && locationState)
        {
            camera.transform.position += new Vector3(0, 10.3f, 0);
            locationState = !locationState;
            collision.gameObject.transform.position = new Vector3(3.8f, -7.3f, -345.9f);
        }
    }
}
