using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] Image image;
    Color color;

    [HideInInspector] bool hideUI = false;

    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Sword sword;

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
            if(dialogueManager != null)
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
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            hideUI = true;
        }

        if (hideUI)
        {
            color.a = Mathf.MoveTowards(color.a, 0f, 2f * Time.deltaTime);
            image.color = color;
        }
    }
}
