    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerAbility : MonoBehaviour
{
    private PlayerSkills playerSkills;

    LevelSystem levelSystem;

    [SerializeField] GameObject fireBall;
    float fireBall_CurrentCoolDown = 0;
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

    int layerMask = 1 << 6;

    float distToCollider;

    private void Start()
    {
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

        if (fireBall_CurrentCoolDown > -1)
        {
            fireBall_CurrentCoolDown -= Time.deltaTime;
        }

        if(frostBite_CurrentCoolDown > -1)
        {
            frostBite_CurrentCoolDown -= Time.deltaTime;
        }

        if(aquaPulse_CurrentCoolDown > -1)
        {
            aquaPulse_CurrentCoolDown -= Time.deltaTime;
        }

        if (zephyrShield_CurrentCoolDown > -1)
        {
            zephyrShield_CurrentCoolDown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Fireball))
            {
                if (fireBall_CurrentCoolDown < 0)
                {
                    Instantiate(fireBall, transform.position, Quaternion.identity);
                    fireBall_CurrentCoolDown = fireBall_CD;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.FrostBite))
            {
                if (frostBite_CurrentCoolDown < 0)
                {
                    Instantiate(frostBite, transform.position, Quaternion.identity);
                    frostBite_CurrentCoolDown = frostBite_CD;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.AquaPulse))
            {
                if (aquaPulse_CurrentCoolDown < 0)
                {
                    Instantiate(aquaPulse, new Vector2(transform.position.x, transform.position.y - (distToCollider - 1f)), Quaternion.identity);
                    aquaPulse_CurrentCoolDown = aquaPulse_CD;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.ZephyrShield))
            {
                if(zephyrShield_CurrentCoolDown < 0)
                {
                    Instantiate(zephyrShield, transform.position, Quaternion.identity);
                    zephyrShield_CurrentCoolDown = zephyrShield_CD;
                }
            }
        }
    }
}
