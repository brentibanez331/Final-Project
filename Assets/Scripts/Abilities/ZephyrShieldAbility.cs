using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VFX;

public class ZephyrShieldAbility : MonoBehaviour
{
    public float duration = 5f;
    VisualEffect visualEffect;

    PlayerCombat playerCombat;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCombat = player.GetComponent<PlayerCombat>();
        visualEffect = gameObject.GetComponentInChildren<VisualEffect>();
        visualEffect.Play();
    }

    void Update()
    {

        if(duration > 0)
        {
            duration -= Time.deltaTime;
            playerCombat.canTakeDamage = false;
        }
        else
        {
            playerCombat.canTakeDamage = true;
        }

        transform.position = player.transform.position;
    }
}
