using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerCombat.TakeDamage(enemy.GetDamage());
        }

    }
}
