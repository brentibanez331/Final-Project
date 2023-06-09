using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystemAnimated : MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    StatePreserve statePreserve;

    private int level;
    private int currentExp;
    int requiredExp;

    GameObject player;

    [SerializeField] LevelSystem levelSystem;

    [SerializeField] PlayerHealthBar healthBar;

    private bool isAnimating;
    private void Awake()
    {
        statePreserve = GameObject.FindGameObjectWithTag("StatePreserve").GetComponent<StatePreserve>();

        //Debug
        level = levelSystem.GetLevelNumber();
        currentExp = levelSystem.GetCurrentExp();
        requiredExp = levelSystem.GetRequiredExp();

        level = statePreserve.level;
        currentExp = statePreserve.currentExp;
        requiredExp = statePreserve.requiredExp;

        SetLevelSystem();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetLevelSystem()
    {
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {

    }

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
        currentExp += 5;
        if(currentExp > requiredExp)
        {
            level++;
            player.GetComponent<PlayerCombat>().currentHealth = player.GetComponent<PlayerCombat>().maxHealth;
            healthBar.SetHealth(player.GetComponent<PlayerCombat>().currentHealth, player.GetComponent<PlayerCombat>().maxHealth);

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
