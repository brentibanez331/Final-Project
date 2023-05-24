using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExpLoot : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float upwardVelocity = 2f;
    float lifeSpan = 5f;

    public int experienceValue;

    VisualEffect visualEffect;

    float alphaAmount;
    float duration = 2f;
    float timeElapsed = 0;

    GameObject player;
    LevelSystem levelSystem;

    void Start()
    {
        player = GameObject.Find("Player");

        levelSystem = player.GetComponent(typeof(LevelSystem)) as LevelSystem;

        visualEffect = GetComponent<VisualEffect>();

        rb.AddForce(transform.up * upwardVelocity, ForceMode2D.Impulse);
    }

    void Update()
    {
        if(lifeSpan > 0)
        {
            lifeSpan -= Time.deltaTime;
        }
        else
        {
            if(timeElapsed < duration)
            {
                alphaAmount = Mathf.Lerp(1f, -1f, timeElapsed / duration);
                visualEffect.SetFloat("ParticleAlpha", alphaAmount);

                Debug.Log(alphaAmount);
                timeElapsed += Time.deltaTime;
            }
            
            if(timeElapsed >= duration)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetExpValue(int value)
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
