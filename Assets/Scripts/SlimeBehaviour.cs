using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    [HideInInspector] public bool targetPlayer = false;
    bool isGrounded = false;
    [SerializeField] private Vector2 jumpDirection_min;
    [SerializeField] private Vector2 jumpDirection_max;
    private Vector2 jumpDirection;
    [HideInInspector] public float direction;
    bool movingRight;


    Rigidbody2D rb;
    [SerializeField] Transform hpBarPlaceholder;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    float timeRemaining = 1f;
    [SerializeField] float timeIntervals;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jumpDirection = new Vector2(Random.Range(jumpDirection_min.x, jumpDirection_max.x), Random.Range(jumpDirection_min.y, jumpDirection_max.y));

        //Need Fixes
        if (isGrounded)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if(!movingRight)
                {
                    rb.AddForce(new Vector2(-jumpDirection.x, jumpDirection.y), ForceMode2D.Impulse);
                    transform.localScale = new Vector2(-1, 1);
                    if (hpBarPlaceholder.localScale.x > 0)
                    {
                        hpBarPlaceholder.localScale = new Vector2(-hpBarPlaceholder.localScale.x, hpBarPlaceholder.localScale.y);
                    }

                }
                else
                {
                    rb.AddForce(new Vector2(jumpDirection.x, jumpDirection.y), ForceMode2D.Impulse);
                    transform.localScale = new Vector2(1, 1);
                    hpBarPlaceholder.localScale = new Vector2(Mathf.Abs(hpBarPlaceholder.localScale.x), hpBarPlaceholder.localScale.y);
                }
            }

            if (!targetPlayer)
            {
                //Enemy succeeds point A, change direction
                if (transform.position.x < pointA.position.x)
                {
                    movingRight = true;
                }

                //Enemy succeeds point B, change direction
                if (transform.position.x > pointB.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                if(direction < 0)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }
            }
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
            timeRemaining = timeIntervals;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
