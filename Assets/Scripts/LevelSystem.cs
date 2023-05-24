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

    public LevelSystem()
    {
        level = 1;
        currentExp = 0;
        requiredExp = 500;
    }

    public void GainExp(int expValue)
    {
        currentExp += expValue;
        while(currentExp >= requiredExp)
        {
            level++;
            currentExp -= requiredExp;
        }

        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }
    public float GetExpNormalized()
    {
        return (float) currentExp / requiredExp;
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
