using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FrostBiteAbility : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;

    bool isMoving = true;
    bool enemyDetected = false;

    Transform enemyTransform;

    Enemy enemy;

    float direction;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (enemyDetected)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemyTransform.position.x, transform.position.y), speed);
            }
            else
            {
                transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
                transform.localScale = new Vector2(1 * -direction, 1);
            }
        }
        
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void DamageEnemy()
    {
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Enemy Detected");
            enemyDetected = true;
            enemyTransform = collision.gameObject.transform;
            enemy = collision.gameObject.GetComponent<Enemy>();
        }    
    }

   
}
