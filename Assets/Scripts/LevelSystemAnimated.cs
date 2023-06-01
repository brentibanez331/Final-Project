using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystemAnimated : MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int currentExp;
    int requiredExp;

    [SerializeField] LevelSystem levelSystem;
    private bool isAnimating;
    private void Awake()
    {
        SetLevelSystem();

        level = levelSystem.GetLevelNumber();
        currentExp = levelSystem.GetCurrentExp();
        requiredExp = levelSystem.GetRequiredExp();

        Debug.Log("LevelSystemAnim");
    }
    public void SetLevelSystem()
    {
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        //SetLevelNumber(levelSystem.GetLevelNumber());

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        //SetLevelNumber(levelSystem.GetLevelNumber());
    }

    /*private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        levelText.text = level.ToString();
    }*/

    private void Update()
    {
        if (isAnimating)
        {
            if (level < levelSystem.GetLevelNumber())
            {
                //Local level under target level
                AddExperience();
            }
            else
            {
                //Local level equals target level
                if (currentExp < levelSystem.GetCurrentExp())
                {
                    AddExperience();
                }
                else
                {
                    isAnimating = false;
                }
            }
        }
    }

    private void AddExperience() 
    {
        currentExp += 4;
        if(currentExp > requiredExp)
        {
            level++;
            currentExp = 0;
            if(OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    /*private void SetLevelNumber(int levelNumber)
    {
        levelText.text = levelNumber.ToString();
    }*/

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExpNormalized()
    {
        float expNormalized = (float) currentExp / requiredExp;
        return expNormalized;
    }
}
