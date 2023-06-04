using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    [HideInInspector] public bool canAccessSkillTree;
    [SerializeField] PlayerCombat playerCombat;

    [SerializeField] PauseManager pauseManager;

    [SerializeField] CanvasGroup skillUICanvasGroup;

    [SerializeField] GameObject pauseHandler;
    [SerializeField] GameObject pauseCanvas;

    [SerializeField] TextMeshProUGUI abilityName;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI cooldown_value;
    [SerializeField] TextMeshProUGUI cooldown_text;
    [SerializeField] TextMeshProUGUI damage_value;
    [SerializeField] TextMeshProUGUI damage_text;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI instruction;

    [SerializeField] PlayerAbility playerAbility;
    [SerializeField] FireBallAbility fireBallAbility;
    [SerializeField] FrostBiteAbility frostBiteAbility;
    [SerializeField] AquaPulseAbility aquaPulseAbility;
    [SerializeField] ZephyrShieldAbility zephyrShieldAbility;

    private PlayerSkills playerSkills;
    [SerializeField] LevelSystem levelSystem;

    [SerializeField] Image fireBall;
    [SerializeField] Sprite fireBallUnlocked;
    [SerializeField] Image frostBite;
    [SerializeField] Sprite frostBiteUnlocked;
    [SerializeField] Image aquaPulse;
    [SerializeField] Sprite aquaPulseUnlocked;
    [SerializeField] Image zephyrShield;
    [SerializeField] Sprite zephyrShieldUnlocked;

    Button fireBallButton;
    Button frostBiteButton;
    Button zephyrShieldButton;
    Button aquaPulseButton;
    ColorBlock cb;

    bool isOpen = false;

    private void Start()
    {
        fireBallButton = fireBall.GetComponent<Button>();
        frostBiteButton = frostBite.GetComponent<Button>();
        zephyrShieldButton = zephyrShield.GetComponent<Button>();
        aquaPulseButton = aquaPulse.GetComponent<Button>();
        playerSkills = levelSystem.GetPlayerSkills();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (canAccessSkillTree)
            {
                if (!isOpen)
                {
                    StartCoroutine(ShowUI());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
            {
                StartCoroutine(HideUI());
               
            }
        }

        if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Fireball))
        {
            fireBall.sprite = fireBallUnlocked;
            cb = fireBallButton.colors;
            cb.normalColor = Color.white;
            fireBallButton.colors = cb;
        }
        if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.FrostBite))
        {
            frostBite.sprite = frostBiteUnlocked;
            cb = frostBiteButton.colors;
            cb.normalColor = Color.white;
            frostBiteButton.colors = cb;
        }
        if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.AquaPulse))
        {
            aquaPulse.sprite = aquaPulseUnlocked;
            cb = aquaPulseButton.colors;
            cb.normalColor = Color.white;
            aquaPulseButton.colors = cb;
        }
        if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.ZephyrShield))
        {
            zephyrShield.sprite = zephyrShieldUnlocked;
            cb = zephyrShieldButton.colors;
            cb.normalColor = Color.white;
            zephyrShieldButton.colors = cb;
        }
    }

    public void GetSkillName(string name)
    {
        abilityName.text = name;
    }

    public void GetSkillDesc(string desc)
    {
        description.text = desc;
    }

    public void SetSkillInfo()
    {
        if(abilityName.text == "Fireball")
        {
            cooldown_value.text = playerAbility.fireBall_CD.ToString() + " secs";

            damage_value.text = fireBallAbility.damage.ToString();

            if(playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Fireball) == false) 
            {
                levelText.text = "Unlocks at Level ";
                level.text = "2";
            }
            else
            {
                levelText.text = "";
                level.text = "";
            }
            damage_text.text = "Damage: ";
            EnableText();
        }
        if (abilityName.text == "Frostbite")
        {
            cooldown_value.text = playerAbility.frostBite_CD.ToString() + " secs";

            damage_value.text = frostBiteAbility.damage.ToString();

            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.FrostBite) == false)
            {
                levelText.text = "Unlocks at Level ";
                level.text = "3";
            }
            else
            {
                levelText.text = "";
                level.text = "";
            }
            damage_text.text = "Damage: ";
            EnableText();
        }
        if (abilityName.text == "Aqua Pulse")
        {
            cooldown_value.text = playerAbility.aquaPulse_CD.ToString() + " secs";

            damage_value.text = aquaPulseAbility.damage.ToString();

            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.AquaPulse) == false)
            {
                levelText.text = "Unlocks at Level ";
                level.text = "4";
            }
            else
            {
                levelText.text = "";
                level.text = "";
            }
            damage_text.text = "Damage: ";
            EnableText();
        }

        if (abilityName.text == "Zephyr Shield")
        {
            cooldown_value.text = playerAbility.zephyrShield_CD.ToString() + " secs";

            damage_value.text = zephyrShieldAbility.duration.ToString() + " secs";

            if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.ZephyrShield) == false)
            {
                levelText.text = "Unlocks at Level ";
                level.text = "3";
            }
            else
            {
                levelText.text = "";
                level.text = "";
            }
            damage_text.text = "Duration: ";
            EnableText();
        }
    }

    void EnableText()
    {
        instruction.text = "";
        cooldown_text.text = "CD: ";
        
    }

    void DisableText()
    {
        abilityName.text = "";
        description.text = "";
        cooldown_value.text = "";
        cooldown_text.text = "";
        damage_value.text = "";
        damage_text.text = "";
        levelText.text = "";
        level.text = "";
        instruction.text = "Select an ability to view description";
    }

    IEnumerator ShowUI()
    {
        playerCombat.enabled = false;
        pauseHandler.GetComponent<PauseHandler>().enabled = false;

        while (skillUICanvasGroup.alpha < 1f)
        {
            skillUICanvasGroup.alpha = Mathf.MoveTowards(skillUICanvasGroup.alpha, 1f, 2f * Time.deltaTime);

            yield return null;
        }
        isOpen = true;
        pauseCanvas.SetActive(false);
        pauseManager.PauseGame();
    }

    IEnumerator HideUI()
    {
        isOpen = false;
        pauseManager.ResumeGame();

        while (skillUICanvasGroup.alpha > 0f)
        {
            skillUICanvasGroup.alpha = Mathf.MoveTowards(skillUICanvasGroup.alpha, 0f, 2f * Time.deltaTime);

            yield return null;
        }

        pauseCanvas.SetActive(true);
        playerCombat.enabled = true;
        pauseHandler.GetComponent<PauseHandler>().enabled = true;
        DisableText();
    }


}
