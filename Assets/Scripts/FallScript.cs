using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    [SerializeField] Transform checkPoint;

    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] int damage;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = checkPoint.position;
            playerCombat.TakeDamage(damage);
        }
    }
}
