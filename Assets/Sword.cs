using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Transform player;
    [SerializeField] float followSpeed = 3f;
    float xPosOffset = 0.7f;
    Vector3 newPos;

    bool followPlayer = false;

    Animator anim;

    [SerializeField] ParticleSystem idleParticles;
    //ParticleSystem.MainModule main_idleParticles;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim.SetBool("isRotating", true);
        //main_idleParticles = idleParticles.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            anim.enabled = false;

            if (player.transform.localScale.x == 1)
            {
                newPos = new Vector3(player.transform.position.x + xPosOffset * -1, player.transform.position.y + 0.3f, -0.2f);
            }
            else
            {
                newPos = new Vector3(player.transform.position.x + xPosOffset, player.transform.position.y + 0.3f, -0.2f);
            }

            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            followPlayer = true;
            idleParticles.Stop();
            anim.SetBool("isRotating", false);
        }
    }
}
