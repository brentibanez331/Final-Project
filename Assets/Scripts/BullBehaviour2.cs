using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBehaviour2 : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [SerializeField] float speed;
    [HideInInspector] public Animator anim;
    [SerializeField] Transform hpBarPlaceholder;

    [SerializeField] AudioSource chargeSFX;

    float timeRemaining = 3f;

    bool movingLeft = true;
    bool pointReached = false;
    bool canMove = true;
    bool playerDetected = false;

    int direction = 1;
    Vector2 rayDirection = new Vector2(-1, 0);

    int playerLayer = 1 << 7;

    float distance;
    float target_x;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        target_x = currentMovementTarget();
    }

    // Update is called once per frame
    void Update()
    {
        target_x = currentMovementTarget();

        Vector2 target = new Vector2(target_x, transform.position.y);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, distance, playerLayer);
        distance = (target - (Vector2)transform.position).magnitude;
        

        if (hit.collider != null)
        {
            if(hit.collider.name == "Player")
            {
                if (!playerDetected)
                {
                    chargeSFX.Play();
                    anim.SetTrigger("playerDetected");
                    playerDetected = true;
                    canMove = false;
                    speed = 15f;
                    Debug.Log("Start charge attack");
                }
                
            }
        }

        if (canMove)
        {
            anim.SetBool("isWalking", true);
            if (!movingLeft)
            {

                rayDirection = new Vector2(1, 0);
                transform.localScale = new Vector2(-1, 1);
                if (hpBarPlaceholder.localScale.x > 0)
                {
                    hpBarPlaceholder.localScale = new Vector2(-hpBarPlaceholder.localScale.x, hpBarPlaceholder.localScale.y);
                }

            }
            else
            {
                rayDirection = new Vector2(-1, 0);
                transform.localScale = new Vector2(1, 1);
                hpBarPlaceholder.localScale = new Vector2(Mathf.Abs(hpBarPlaceholder.localScale.x), hpBarPlaceholder.localScale.y);
                
            }
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            Debug.DrawRay(transform.position + new Vector3(0, 0.5f), rayDirection * distance, Color.red);
        }

        if (distance <= 0.1f)
        {
            if (timeRemaining > 0)
            {
                anim.SetBool("isWalking", false);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                direction *= -1;
                playerDetected = false;
                speed = 3f;
                timeRemaining = 3f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!canMove && playerDetected)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
            {
                Debug.Log("animation ended");
                canMove = true;
            }
        }
    }

    float currentMovementTarget()
    {
        if (direction == 1)
        {
            movingLeft = true;
            return pointA.position.x;
        }
        else
        {
            movingLeft = false;
            return pointB.position.x;
        }
    }
}
