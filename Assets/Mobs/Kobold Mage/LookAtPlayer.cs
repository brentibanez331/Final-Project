using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    //[SerializeField] private Transform target;
    private GameObject target;

    void Awake()
    {
        target = GameObject.Find("Player");
    }
    void Update()
    {
        Vector2 direction = new Vector2(target.gameObject.transform.position.x - transform.position.x, target.gameObject.transform.position.y - transform.position.y);
        direction = Quaternion.Euler(0f, 0f, 0f) * direction; // Rotate the direction vector by 90 degrees
        transform.up = direction;
    }
}
