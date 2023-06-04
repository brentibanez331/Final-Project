using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    [SerializeField] private int level;
    [SerializeField] private int currentExp;
    [SerializeField] int requiredExp;

    private PlayerSkills playerSkills;

    public LevelSystem()
    {
        level = 1;
        currentExp = 200;
        requiredExp = 500;
        playerSkills = new PlayerSkills();
    }

    public PlayerSkills GetPlayerSkills()
    {
        return playerSkills;
    }

    private void Update()
    {
        if(level >= 2)
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.Fireball);
        }
        if (level >= 3)
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.FrostBite);
            playerSkills.UnlockSkill(PlayerSkills.SkillType.ZephyrShield);
        }
        if(level >= 4)
        {
            playerSkills.UnlockSkill(PlayerSkills.SkillType.AquaPulse);
        }
    }

    public void GainExp(int expValue)
    {
        currentExp += expValue;
        while(currentExp >= requiredExp)
        {
            level++;
            currentExp -= requiredExp;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }

        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }
    public float GetExpNormalized()
    {
        float expNormalized = (float) currentExp / requiredExp;
        return expNormalized;
    }

    public int GetCurrentExp()
    {
        return currentExp;
    }

    public int GetRequiredExp()
    {
        return requiredExp;
    }
}
