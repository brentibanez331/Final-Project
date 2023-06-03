using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [SerializeField] float speed;

    int direction = 1;

    void Update()
    {
        Vector2 target = currentMovementTarget();

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)transform.position).magnitude;

        if(distance <= 0.1f)
        {
            direction *= -1;
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
        if(collision.collider.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
