using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement2 : MonoBehaviour
{
    [SerializeField] SceneHandler sceneHandler;
    [SerializeField] string sceneName;

    [SerializeField] StatePreserve stateSettings;

    [SerializeField] LevelSystem levelSystem;
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] SkillTreeManager skillTreeManager;
    [SerializeField] ExperienceBar expBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stateSettings.level = levelSystem.GetLevelNumber();
            stateSettings.currentExp = levelSystem.GetCurrentExp();
            stateSettings.requiredExp = levelSystem.GetRequiredExp();
            stateSettings.currentHealth = playerCombat.currentHealth;
            stateSettings.maxHealth = playerCombat.maxHealth;
            stateSettings.playerSkills = levelSystem.GetPlayerSkills();

            stateSettings.fireball = skillTreeManager.fireBall.sprite;
            stateSettings.frostbite = skillTreeManager.frostBite.sprite;
            stateSettings.zephyr = skillTreeManager.zephyrShield.sprite;
            stateSettings.aquapulse = skillTreeManager.aquaPulse.sprite;

            stateSettings.expFillAmount = expBar.expFill.fillAmount;

            sceneHandler.StartFade(sceneName);
        }
    }
}
