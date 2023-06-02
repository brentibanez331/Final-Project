using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    float speed = 5;

    [SerializeField] IntroSystem introSystem;
    [SerializeField] GameObject introObject;

    // Update is called once per frame
    public void Update()
    {
        if (introSystem.canvasRegaining)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, 0.5f * Time.deltaTime);
        }

        if(canvasGroup.alpha >= 1)
        {
            Destroy(introObject);
        }
    }
}
