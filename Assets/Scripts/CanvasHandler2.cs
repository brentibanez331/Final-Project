using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler2 : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Image image;
    Color img_color;

    float timeRemaining = 2f;

    // Start is called before the first frame update
    void Start()
    {
        img_color = image.color;
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            img_color.a = Mathf.MoveTowards(img_color.a, 0f, 1.5f * Time.deltaTime);
            image.color = img_color;

            if (img_color.a <= 0)
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 1f, 2 * Time.deltaTime);
            }
        }

        
    }
}
