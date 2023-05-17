using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLoot : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float upwardVelocity = 2f;
    float lifeSpan = 10f;

    public float experienceValue;

    GameObject player;
    LevelSystem levelSystem;

    void Start()
    {
        player = GameObject.Find("Player");

        levelSystem = player.GetComponent(typeof(LevelSystem)) as LevelSystem;

        rb.AddForce(transform.up * upwardVelocity, ForceMode2D.Impulse);
    }

    public void SetExpValue(float value)
    {
        experienceValue = value;    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            levelSystem.GainExp(experienceValue);
            Destroy(gameObject);
        }
    }
}
