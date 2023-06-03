using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    float jumpForce = 7f;
    bool isGrounded;

    float speed = 5f;

    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            speed = 4f;
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
            if (horizontalInput < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
            anim.SetBool("isWalking", true);
            transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            speed = 5f;
            isGrounded = true;
        }
    }
    
}
