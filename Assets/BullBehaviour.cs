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

    float timeRemaining;
    Vector3 targetPosition;
    float newX_Pos;
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
            

            if (transform.position.x < targetPosition.x)
            {
                newX_Pos = Random.Range(-5f, 5f);
                targetPosition = new Vector3(newX_Pos, transform.position.y, transform.position.z);
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }

            StartCoroutine(Move());
            timeRemaining = 5f;
        }
        
    }
    IEnumerator Move()
    {
        while(transform.position != targetPosition)
        {
            

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            yield return null;
        }
    }

}
