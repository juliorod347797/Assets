using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerct : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        moveSpeed = 3f;
        jumpForce = 60f;
        isJumping = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "platform") 
        {
            isJumping = false;
        }
       
    }
    void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "platform") 
        {
            isJumping = true;
        }
    }
}
