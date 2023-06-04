using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] Image image;
    Color color;

    [HideInInspector] public bool hideUI = false;
    [HideInInspector] public bool uiIsHidden = false;

    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Sword sword;
    [SerializeField] ExperienceBar expBar;

    [SerializeField] PauseManager pauseManager;
    [SerializeField] GameObject pauseHandler;
    [SerializeField] SkillTreeManager skillTreeManager;

    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        color = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hideUI)
        {
            if(skillTreeManager != null)
            {
                skillTreeManager.canAccessSkillTree = false;
            }

            if (dialogueManager != null)
            {
                if (dialogueManager.dialogueEnded)
                {
                    color.a = Mathf.MoveTowards(color.a, 1f, 2f * Time.deltaTime);
                    image.color = color;
                }
            }

            if(sword != null)
            {
                if (sword.swordTouched)
                {
                    color.a = Mathf.MoveTowards(color.a, 1f, 2f * Time.deltaTime);
                    image.color = color;
                }
            }

            if(expBar != null)
            {
                if (expBar.isLevel2)
                {
                    color.a = Mathf.MoveTowards(color.a, 1f, 2f * Time.deltaTime);
                    image.color = color;
                }
            }

            if(color.a == 1f)
            {
                pauseManager.PauseGame();
                playerMovement.walkSFX.enabled = false;
                if(playerCombat != null)
                {
                    playerCombat.enabled = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseManager != null)
            {
                playerMovement.walkSFX.enabled = true;
                pauseManager.ResumeGame();
                hideUI = true;
            }
        }

        if (hideUI)
        {
            color.a = Mathf.MoveTowards(color.a, 0f, 2f * Time.deltaTime);
            image.color = color;

            if(image.color.a <= 0f)
            {
                uiIsHidden = true;
                if(skillTreeManager != null)
                {
                    skillTreeManager.canAccessSkillTree = true;
                }
                if(pauseHandler != null)
                {
                    pauseHandler.GetComponent<PauseHandler>().enabled = true;
                }
                if(playerCombat != null)
                {
                    playerCombat.enabled = true;
                }
                gameObject.GetComponent<TutorialManager>().enabled = false;
            }
        }
    }
}
