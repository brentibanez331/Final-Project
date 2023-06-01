using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    string scene_Name;
    [SerializeField] GameObject fadeImage;
    [SerializeField] SceneTransition sceneTransition;

    public void StartFade(string sceneName)
    {
        scene_Name = sceneName;
        fadeImage.SetActive(true);
        sceneTransition.StartingFade();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene_Name);
    }

    public void QuitGame()
    {
        Debug.Log("Game Has Quit");
        Application.Quit();
    }
}
