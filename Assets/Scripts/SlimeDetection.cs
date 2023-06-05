using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDetection : MonoBehaviour
{
    [SerializeField] SlimeBehaviour slimeBehaviour;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            slimeBehaviour.targetPlayer = true;
            slimeBehaviour.direction = collision.transform.position.x - transform.parent.position.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            slimeBehaviour.targetPlayer = false;
        }
    }
}
