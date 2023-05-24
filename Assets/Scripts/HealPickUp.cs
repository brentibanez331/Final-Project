using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour
{
    [SerializeField] private ParticleSystem healCut;
    [SerializeField] private ParticleSystem healParticles;
    [SerializeField] private PlayerCombat playerCombat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            healCut.Play();
            healParticles.Play();
            playerCombat.HealDamage(20);
            Destroy(gameObject);
        }
    }
}
