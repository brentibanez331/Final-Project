using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitArea : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider2d;

    private Vector2 centerCollider; //the center of the collider
    private Vector2 extentsCollider; //half the orientation of a collider
    private Vector2[] colliderSides = new Vector2[2]; //the outmost left and right sides of the collider


    void Start()
    {
        centerCollider = collider2d.bounds.center;
        extentsCollider = collider2d.bounds.extents;
        
        colliderSides[0] = new Vector2(centerCollider.x - extentsCollider.x, centerCollider.y);
        colliderSides[1] = new Vector2(centerCollider.x + extentsCollider.x, centerCollider.y);
    }
    public void InstantiateBarrier(GameObject barrier)
    {
        for(int i = 0; i <= 1; i++)
        {
            Instantiate(barrier, new Vector2(colliderSides[i].x, colliderSides[i].y), Quaternion.identity);
        }
        
    }
}
