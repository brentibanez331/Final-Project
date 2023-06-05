    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    private PlayerSkills playerSkills;

    LevelSystem levelSystem;

    [SerializeField] GameObject fireBall;
    [HideInInspector] public float fireBall_CurrentCoolDown = 0;
    [SerializeField] public float fireBall_CD = 3f;

    [SerializeField] GameObject frostBite;
    float frostBite_CurrentCoolDown = 0;
    [SerializeField] public float frostBite_CD = 3f;

    [SerializeField] GameObject aquaPulse;
    float aquaPulse_CurrentCoolDown = 0;
    [SerializeField] public float aquaPulse_CD = 3f;

    //[SerializeField] VisualEffect zephyrShield;
    [SerializeField] GameObject zephyrShield;
    float zephyrShield_CurrentCoolDown = 0;
    [SerializeField] public float zephyrShield_CD = 3f;

    [SerializeField] Image fireCDFill;
    [SerializeField] Image frostCDFill;
    [SerializeField] Image aquaCDFill;
    [SerializeField] Image zephyrCDFill;

    [SerializeField] AudioSource fireBallSFX;
    [SerializeField] AudioSource frostBiteSFX;
    [SerializeField] AudioSource aquaPulseSFX;
    [SerializeField] AudioSource zephyrShieldSFX;


    int layerMask = 1 << 6;

    float distToCollider;

    private void Start()
    {

        fireCDFill.fillAmount = 0f;
        frostCDFill.fillAmount = 0f;
        aquaCDFill.fillAmount = 0f;
        zephyrCDFill.fillAmount = 0f;

        levelSystem = gameObject.GetComponent<LevelSystem>();
        playerSkills = levelSystem.GetPlayerSkills();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, 20f, layerMask);

        if (hit.collider != null)
        {
            distToCollider = hit.distance;
        }

        if (fireBall_CurrentCoolDown > 0)
        {
            fireBall_CurrentCoolDown -= Time.deltaTime;
        }

        if(frostBite_CurrentCoolDown > 0)
        {
            frostBite_CurrentCoolDown -= Time.deltaTime;
        }

        if(aquaPulse_CurrentCoolDown > 0)
        {
            aquaPulse_CurrentCoolDown -= Time.deltaTime;
        }

        if (zephyrShield_CurrentCoolDown > 0)
        {
            zephyrShield_CurrentCoolDown -= Time.deltaTime;
        }

        //Fireball cast
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Fireball));

            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Fireball))
            {
                if (fireBall_CurrentCoolDown <= 0)
                {
                    Instantiate(fireBall, transform.position, Quaternion.identity);
                    fireBallSFX.Play();
                    fireBall_CurrentCoolDown = fireBall_CD;
                    fireCDFill.fillAmount = 1f;
                    StartCoroutine(FireBallCD());
                }
            }
        }

        //Frostbite
        if (Input.GetKeyDown(KeyCode.E))
        {   
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.FrostBite))
            {
                if (frostBite_CurrentCoolDown <= 0)
                {
                    frostBiteSFX.Play();
                    Instantiate(frostBite, transform.position, Quaternion.identity);
                    frostBite_CurrentCoolDown = frostBite_CD;
                    frostCDFill.fillAmount = 1f;
                    StartCoroutine(FrostBiteCD());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.AquaPulse))
            {
                if (aquaPulse_CurrentCoolDown <= 0)
                {
                    aquaPulseSFX.Play();
                    Instantiate(aquaPulse, new Vector2(transform.position.x, transform.position.y - (distToCollider - 1f)), Quaternion.identity);
                    aquaPulse_CurrentCoolDown = aquaPulse_CD;
                    aquaCDFill.fillAmount = 1f;
                    StartCoroutine(AquaPulseCD());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.ZephyrShield))
            {
                if(zephyrShield_CurrentCoolDown <= 0)
                {
                    zephyrShieldSFX.Play();
                    Instantiate(zephyrShield, transform.position, Quaternion.identity);
                    zephyrShield_CurrentCoolDown = zephyrShield_CD;
                    zephyrCDFill.fillAmount = 1f;
                    StartCoroutine(ZephyrShieldCD());
                }
            }
        }
    }

    IEnumerator FireBallCD()
    {
        while (fireCDFill.fillAmount > 0f)
        {
            fireCDFill.fillAmount = fireBall_CurrentCoolDown / fireBall_CD;
            yield return null;
        }
    }

    IEnumerator FrostBiteCD()
    {
        while (frostCDFill.fillAmount > 0f)
        {
            frostCDFill.fillAmount = frostBite_CurrentCoolDown / frostBite_CD;
            yield return null;
        }
    }

    IEnumerator AquaPulseCD()
    {
        while (aquaCDFill.fillAmount > 0f)
        {
            aquaCDFill.fillAmount = aquaPulse_CurrentCoolDown / aquaPulse_CD;
            yield return null;
        }
    }
    IEnumerator ZephyrShieldCD()
    {
        while (zephyrCDFill.fillAmount > 0f)
        {
            zephyrCDFill.fillAmount = zephyrShield_CurrentCoolDown / zephyrShield_CD;
            yield return null;
        }
    }
}
