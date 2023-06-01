using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float lenght, startpos;

    [SerializeField] private GameObject cam;
    [SerializeField] private float parallexEffect;
    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float distance = (cam.transform.position.x * parallexEffect);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
