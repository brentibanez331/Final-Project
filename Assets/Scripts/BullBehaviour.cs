using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BullBehaviour : MonoBehaviour
{
    float timeRemaining = 0;
    private bool isGrounded = false;

    [SerializeField] float speed;
    [SerializeField] public bool isCharging = false;
    [SerializeField] private Transform patrolPoint;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [SerializeField] Transform hpBarPlaceholder;

    [HideInInspector] public bool canWalk = true;
    [HideInInspector] public Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        patrolPoint.position = new Vector2(patrolPoint.position.x, transform.position.y);

        if (isGrounded)
        {
            if (canWalk)
            {

                if (timeRemaining > 0)
                {
                    anim.SetBool("isWalking", false);
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    if (patrolPoint.position.x > transform.position.x)
                    {
                        transform.localScale = new Vector2(-1, 1);
                        if (hpBarPlaceholder.localScale.x > 0)
                        {
                            hpBarPlaceholder.localScale = new Vector2(-hpBarPlaceholder.localScale.x, hpBarPlaceholder.localScale.y);
                        }

                    }
                    else
                    {
                        transform.localScale = new Vector2(1, 1);
                        hpBarPlaceholder.localScale = new Vector2(Mathf.Abs(hpBarPlaceholder.localScale.x), hpBarPlaceholder.localScale.y);
                    }

                    if (patrolPoint.position.x != transform.position.x)
                    {
                        anim.SetBool("isWalking", true);
                        transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, speed * Time.deltaTime);
                    }

                    if ((transform.position.x == patrolPoint.position.x) && !isCharging)
                    {
                        patrolPoint.localPosition = new Vector2(-patrolPoint.localPosition.x, transform.position.y);
                        timeRemaining = 1f;
                    }

                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!canWalk)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0) && isCharging)
            {
                anim.SetBool("isWalking", true);
                StartCoroutine(Charge());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        if(collision.collider.tag == "Player")
        {
            //Physics2D.IgnoreLayerCollision(3, 7, true);
            Debug.Log("Enemy collided with player");
        }
    }

    IEnumerator Charge()
    {
        float dist = Vector2.Distance(patrolPoint.position, transform.position);

        while (transform.position.x != patrolPoint.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, Time.deltaTime);
            yield return null;
        }

        canWalk = true;
        timeRemaining = dist/3;
        isCharging = false;
    }
}
