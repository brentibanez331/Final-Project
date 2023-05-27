using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] ItemDrop itemDrop;

    [SerializeField] int damage;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        //Play hurt animation here

        if(currentHealth <= 0)
        {
            itemDrop.DropLoot();
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
