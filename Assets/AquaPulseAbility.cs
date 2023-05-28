using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AquaPulseAbility : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;

    [SerializeField] Transform hitBox;

    GameObject enemyObject;

    float direction;
    Transform player;

    [SerializeField] float attackRange;

    int enemyLayers = 1 << 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.localScale.x;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        transform.localScale = new Vector2(-1 * -direction, 1);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitBox.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyObject = collision.gameObject;
            StartCoroutine(Sweep(enemyObject));
        }
    }

    IEnumerator Sweep(GameObject enemyObject)
    {
        while (enemyObject != null)
        {
            enemyObject.transform.position = transform.position;
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (hitBox == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(hitBox.position, attackRange);
    }
}
