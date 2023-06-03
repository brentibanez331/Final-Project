using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    [HideInInspector] public bool canAccessSkillTree;

    [SerializeField] PauseManager pauseManager;

    [SerializeField] CanvasGroup skillUICanvasGroup;

    [SerializeField] GameObject pauseHandler;

    [SerializeField] TextMeshProUGUI abilityName;
    [SerializeField] TextMeshProUGUI description;

    bool isOpen = false;

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
    }

    public void GetSkillName(string name)
    {
        
    }

    public void GetSkillDesc(string description)
    {

    }

    IEnumerator ShowUI()
    {
        pauseHandler.GetComponent<PauseHandler>().enabled = false;

        while (skillUICanvasGroup.alpha < 1f)
        {
            skillUICanvasGroup.alpha = Mathf.MoveTowards(skillUICanvasGroup.alpha, 1f, 2f * Time.deltaTime);

            yield return null;
        }
        isOpen = true;
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

        pauseHandler.GetComponent<PauseHandler>().enabled = true;
    }


}
