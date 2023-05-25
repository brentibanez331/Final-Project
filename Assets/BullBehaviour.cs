using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BullBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    //GameObject player;
    [SerializeField] float speed;

    float timeRemaining = 3;
    Vector3 targetPosition;
    float newX_Pos;

    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            

            StartCoroutine(Move());
            timeRemaining = Random.Range(2f, 4f);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);   
    }
    IEnumerator Move()
    {
        while(transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            //transform.Translate(Vector2.right * -transform.localScale.x * speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
            yield return null;
        }

        anim.SetBool("isWalking", false);
    }

}
