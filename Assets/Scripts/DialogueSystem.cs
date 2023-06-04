using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //[SerializeField] IntroSystem introSystem;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    [SerializeField] PlayerMovement playerMovement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.walkSFX.enabled = false;
            dialogueManager.StartDialogue(dialogue);
        }

        if (other.CompareTag("DialogueTrigger"))
        {
            playerMovement.walkSFX.enabled = false;
            dialogueManager.StartDialogue(dialogue);
        }
    }
}
