using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] Material deathMat;

    [SerializeField] private ParticleSystem healCut;
    [SerializeField] private ParticleSystem healParticles;

    float dissolveAmount = 0;
    float dissolveSpeed = 1f;

    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    public PlayerHealthBar playerHealthBar;

    public Transform attackPoint;
    [SerializeField] private Vector2 attackRange = new Vector2(3, 1.5f);
    int attackDamage = 20;
    float attackRate = 2f;
    float nextAttackTime = 0f;

    GameObject sword;
    float timeElapsed_sword = 3f;

    [HideInInspector] public bool canTakeDamage = true;

    //private PlayerSkills playerSkills;

    int enemyLayers = 1 << 3;

    private Shake shake;

    void Start()
    {
        sword = GameObject.FindGameObjectWithTag("Sword");

        deathMat.SetFloat("_DissolveAmount", 0f);

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        playerHealthBar.SetHealth(currentHealth, maxHealth);

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        deathParticle.transform.position = transform.position;

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sword.GetComponent<Sword>().Dissolving();
                Attack();
                timeElapsed_sword = 3f;
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if(timeElapsed_sword > 0)
        {
            timeElapsed_sword -= Time.deltaTime;
        }
        else
        {
            sword.GetComponent<Sword>().Regaining();
        }
        
    }

    void Attack()
    {
        anim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, 0, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            shake.CamShake();

            currentHealth -= damage;

            playerHealthBar.SetHealth(currentHealth, maxHealth);
            //healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                deathParticle.Play();
                StartCoroutine(Death());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Heal")
        {
            healCut.Play();
            healParticles.Play();
        }
    }

    public void HealDamage(int healAmount)
    {
        currentHealth += healAmount;
        playerHealthBar.SetHealth(currentHealth, maxHealth);
        //healthBar.SetHealth(currentHealth);
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
    }

    IEnumerator Death()
    {
        while (dissolveAmount < 1)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + dissolveSpeed * Time.deltaTime);

            deathMat.SetFloat("_DissolveAmount", dissolveAmount);

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
    
