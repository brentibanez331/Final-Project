using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBossScript : MonoBehaviour
{
    [SerializeField] private GameObject target; //target player
    [SerializeField] private Animator anim;

    [SerializeField] private float speed = 1f;

    private float distanceToTarget; //distance of the object to the target 

    private float timer; 

    private bool isAttacking;
    private bool facingRight; //if the object faces in the right
    public bool playerHasEntered = false; //determines if player has entered

    [SerializeField] private GenerateProjectile generateProjectile;

    private SpriteRenderer [] spriteRendererArr;

    void Awake()
    {
        spriteRendererArr = GetComponentsInChildren<SpriteRenderer>();
        generateProjectile = GetComponent<GenerateProjectile>();
    }
    void Update()
    {
        CalculateDistance();
        MoveAnim(distanceToTarget);          
        Flip();
    }
    void FixedUpdate()
    {
        RunTowardsTarget();
    }
    //visual
    void CalculateDistance()
    {
        distanceToTarget = target.transform.position.x - transform.position.x;
    }
    void MoveAnim(float targetDistance)
    {
        anim.SetFloat("isFarFromTarget", Mathf.Abs(targetDistance));
    }
    public void SetPlayerHasEntered(bool playerEnters)
    {
        playerHasEntered = playerEnters;
    }
    void RunTowardsTarget()
    {
        Vector3 targetPosition = new Vector2(target.transform.position.x, transform.position.y); //the distance of the player in the x-axis

        if (playerHasEntered)
        {
            if (Mathf.Abs(distanceToTarget) > 3f && !isAttacking)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isNear", false);
            }
            AttackPlayer();
        }
    }
    void AttackPlayer()
    {
        float duration = 5f; //attacking timer reset
        if (Mathf.Abs(distanceToTarget) < 3f)
        {
            isAttacking = true;
            anim.SetBool("isNear", true);
        }
        if (isAttacking)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= 0)
            {
                StartCoroutine(generateProjectile.ProjectileGenerator());
            }
            else if (timer <= 0)
            {
                isAttacking = false;
                timer = duration;
            }
        }
    }    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triggered");
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("IsHit");
        }       
    }
    IEnumerator IsHit() //flashes the hitColor if Boss was hit
    {
        Color32 hitColor = new Color32(255, 74, 74, 255);
        Color32 normalColor = new Color32(255, 255, 255, 255);

        foreach(SpriteRenderer spriteRenderers in spriteRendererArr)
        {
            spriteRenderers.color = hitColor; 
        }
        yield return new WaitForSeconds(.3f);

        foreach (SpriteRenderer spriteRenderers in spriteRendererArr)
        {
            spriteRenderers.color = normalColor; 
        }
    }
    void Flip()
    {
        if (!isAttacking)
        {
            if ((distanceToTarget < 0 && facingRight) || (distanceToTarget > 0 && !facingRight))
            {
                facingRight = !facingRight;
                transform.Rotate(new Vector3(0f, 180f, 0f)); //rotates the player by 180 deg
            }
        }
    }
/*public void GenerateExplosion(ParticleSystem explosion)
    {
        Instantiate(explosion, transform.localPosition, transform.rotation);
    }*/
}
