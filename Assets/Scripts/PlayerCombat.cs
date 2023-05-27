using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;

    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Transform attackPoint;
    [SerializeField] private Vector2 attackRange = new Vector2(3, 1.5f);
    int attackDamage = 20;
    float attackRate = 2f;
    float nextAttackTime = 0f;
    
    int enemyLayers = 1 << 3;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        //Play attack anim
        anim.SetTrigger("attack");

        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, 0, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //Play hurt animation here

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HealDamage(int healAmount)
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
    }
}
    
