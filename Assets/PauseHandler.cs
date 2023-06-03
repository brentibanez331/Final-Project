using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] PauseManager pauseManager;

    [SerializeField] CanvasGroup pauseCanvasGroup;

    [SerializeField] SkillTreeManager skillTreeManager;

    [SerializeField] GameObject canvasObjects;
    [SerializeField] GameObject skillTree;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseManager.gameIsPaused)
            {
                StartCoroutine(HideUI());
            }
            else
            {
                StartCoroutine(ShowUI());
            }
        }
    }

    IEnumerator ShowUI()
    {
        
        while (pauseCanvasGroup.alpha < 1f)
        {
            pauseCanvasGroup.alpha = Mathf.MoveTowards(pauseCanvasGroup.alpha, 1f, 2f * Time.deltaTime);

            yield return null;
        }
        player.GetComponent<PlayerCombat>().enabled = false;
        skillTree.SetActive(false);
        skillTreeManager.canAccessSkillTree = false;
        pauseManager.PauseGame();
    }

    IEnumerator HideUI()
    {
        pauseManager.ResumeGame();
        while (pauseCanvasGroup.alpha > 0f)
        {
            pauseCanvasGroup.alpha = Mathf.MoveTowards(pauseCanvasGroup.alpha, 0f, 2f * Time.deltaTime);

            yield return null;
        }
        player.GetComponent<PlayerCombat>().enabled = true;
        skillTreeManager.canAccessSkillTree = true;
        skillTree.SetActive(true);


    }
}
