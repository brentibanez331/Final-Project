using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HealPickUp : MonoBehaviour
{
    
    GameObject player;

    [SerializeField] Rigidbody2D rb;
    public float upwardVelocity = 3f;
    float lifeSpan = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb.AddForce(transform.up * upwardVelocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            
            player.GetComponent<PlayerCombat>().HealDamage(20);
            Destroy(gameObject);
        }
    }
}
