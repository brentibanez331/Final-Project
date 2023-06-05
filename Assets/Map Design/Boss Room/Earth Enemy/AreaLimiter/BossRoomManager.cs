using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomManager : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject earthBoss;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject explosion;

    private Enemy enemy;
    private bool canCast = false;
    private bool isInside = false;
    public bool isDead = true;
    private bool onDialogue = false;

    [SerializeField] private LimitArea limitArea;
    private EarthBossScript earthBossScript;
    private CastProjectile castProjectile;

    public GameObject HealthBarUI;

    private Vector3 bossLoc;

    [SerializeField] AudioSource deathSFX;

    [SerializeField] SceneHandler sceneHandler;

    [SerializeField] private GameObject EndDialogue;
    void Awake()
    {
        enemy = GameObject.Find("Boss_earth").GetComponent<Enemy>();

        castProjectile = GameObject.Find("Caster").GetComponent<CastProjectile>();
        
    }
    private void Start()
    {
        HealthBarUI.SetActive(false);
    }
    private void Update()
    {
        //Debug.Log(enemy.currentHealth);
        if (canCast)
        {
            StartCoroutine(Cast());
        }
        if (isInside)
        {

            StartCoroutine(InitiateBarrier()); //function that starts when player enters the collider          
            if(HealthBarUI != null)
            {
                HealthBarUI.SetActive(true);
            }              
        }
        if(enemy.currentHealth > 0)
        {
            bossLoc = new Vector3(earthBoss.transform.position.x, earthBoss.transform.position.y + .3f, earthBoss.transform.position.z);
        }
        if (enemy.currentHealth <= 0)
        {
            if (isDead)
            {
                deathSFX.Play();
                GenerateExplosion(explosion);
                StartCoroutine(InitiateExitWindow());
                isDead = false;
            }  

            isInside = false;
            for (int i = 0; i < 2; i++)
            {
                //Debug.Log(limitArea.barrierArray[i].gameObject.name);
                Destroy(limitArea.barrierArray[i]);
            }
        }

        if (onDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onDialogue = false;
                sceneHandler.StartFade("MainMenu");
                EndDialogue.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            if(earthBoss != null)
            {
                earthBossScript = earthBoss.GetComponent<EarthBossScript>();
            }           
            earthBossScript.SetPlayerHasEntered(true);
            isInside = true;
            canCast = true;
        }
    }
    IEnumerator InitiateBarrier()
    {      
        isInside = false;
        yield return new WaitForSeconds(.5f);
        
        if (enemy.currentHealth > 0)
        {
            if(limitArea != null)
            {
                limitArea.InstantiateBarrier(barrier); //function to instantiate a barrier to prevent player from leaving
            }
        }
    }
    IEnumerator Cast()
    {  
        if (enemy.currentHealth > 0f)
        {
            canCast = false;
            yield return new WaitForSeconds(3f);
            castProjectile.Cast(projectile);
            canCast = true;
        }
        else if (enemy.currentHealth <= 0f)
        {
            canCast = false;
        }       
    }
    void GenerateExplosion(GameObject explosion)
    {
        GameObject explosionObject = Instantiate(explosion, bossLoc, transform.rotation);
        explosionObject.transform.localScale = new Vector2(1.5f, 1.5f);
        Destroy(explosionObject, .5f);
    }
    IEnumerator InitiateExitWindow()
    {
        yield return new WaitForSeconds(4f);

        EndDialogue.SetActive(true);
        Time.timeScale = 0;
        onDialogue = true;
        yield return null;
    }
}
