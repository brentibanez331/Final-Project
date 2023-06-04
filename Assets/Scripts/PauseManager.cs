using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;

    public bool gameIsPaused = false;

    // Start is called before the first frame update
    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
}
