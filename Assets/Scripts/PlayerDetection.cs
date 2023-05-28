using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] BullBehaviour bullBehaviour;

    [SerializeField] float coolDown = 3f;

    bool canCast = true;

    private void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            canCast = false;

        }
        else
        {
            canCast = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bullBehaviour.canWalk = false;

            if (canCast)
            {
                bullBehaviour.anim.SetTrigger("playerDetected");
                coolDown = 3;
            }

            bullBehaviour.isCharging = true;
        }
    }
}