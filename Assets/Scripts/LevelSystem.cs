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
        Debug.Log("Level System");
        level = 1;
        currentExp = 200;
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
        float expNormmalized = (float) currentExp / requiredExp;
        return expNormmalized;
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
