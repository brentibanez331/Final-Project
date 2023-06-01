using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Animator anim;
    string sceneName;

    [SerializeField] SceneHandler sceneHandler;

    /*public void LoadScene(string scene_Name)
    {
        anim.Play("FadeIn");
        sceneName = scene_Name;
        
    }*/
    public void EndFade()
    {
        gameObject.SetActive(false);
    }

    public void StartingFade()
    {
        //gameObject.SetActive(false);
        anim.SetTrigger("fadeStart");
    }
   
    public void FadeComplete()
    {
        sceneHandler.ChangeScene();
    }

    
}
