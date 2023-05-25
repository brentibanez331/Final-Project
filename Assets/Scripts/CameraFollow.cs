using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    float followSpeed = 2f;

    float timeRemaining = 3f;

    [SerializeField] Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            Vector3 newPos = new Vector3(targetEnemy.position.x, targetEnemy.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }

        if(player == null)
        {
            transform.position = transform.position;
        }
        else
        {
            Vector3 newPos = new Vector3(player.position.x, player.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
