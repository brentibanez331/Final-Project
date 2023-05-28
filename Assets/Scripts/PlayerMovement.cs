using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float jumpForce = 7f;
    bool isGrounded;

    float speed = 5f;

    private Animator anim;
    private Rigidbody2D rb;

    //public Transform hpBarPlaceholder;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("takeOff");
            isGrounded = false;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput == 0)
        {
            //Play idle animation
            anim.SetBool("isWalking", false);
        }
        else
        {
            //Flip character sprite
            if(horizontalInput < 0)
            {
                transform.localScale = new Vector2(-1, 1);
                /*if (hpBarPlaceholder.localScale.x > 0)
                {
                    hpBarPlaceholder.localScale = new Vector2(-hpBarPlaceholder.localScale.x, hpBarPlaceholder.localScale.y);
                }*/
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
                //hpBarPlaceholder.localScale = new Vector2(Mathf.Abs(hpBarPlaceholder.localScale.x), hpBarPlaceholder.localScale.y);

                //hpBarPlaceholder.localScale = hpBarPlaceholder.localScale * -1;
            }
            //Play walk animation
            anim.SetBool("isWalking", true);
            transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    
}
