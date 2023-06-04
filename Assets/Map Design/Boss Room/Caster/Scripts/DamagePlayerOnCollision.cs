using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnCollision : MonoBehaviour
{
    PlayerCombat playerCombat;
    GameObject boss;
    Enemy enemy;

    private void Awake()
    {
        boss = GameObject.Find("Boss_earth");
        if(boss != null)
        {
            enemy = boss.GetComponent<Enemy>();
        }
        playerCombat = FindObjectOfType<PlayerCombat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(enemy != null)
            {
                playerCombat.TakeDamage(enemy.GetDamage());
            }                        
        }
    }
}
