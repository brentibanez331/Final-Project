using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform2 : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [SerializeField] float speed;

    int direction = 1;

    bool canMove = false;

    void Update()
    {
        if (canMove)
        {
            Vector2 target = currentMovementTarget();

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            float distance = (target - (Vector2)transform.position).magnitude;

            if (distance <= 0.1f)
            {
                direction *= -1;
            }
        }
        
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return pointA.position;
        }
        else
        {
            return pointB.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            canMove = true;
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            canMove = false;
            collision.transform.parent = null;
        }
    }
}
