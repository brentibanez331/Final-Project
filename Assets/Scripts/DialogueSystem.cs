using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //[SerializeField] IntroSystem introSystem;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;


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
            dialogueManager.StartDialogue(dialogue);
            //introSystem.playerAnim.SetBool("isWalking", false);
            //introSystem.isWalking = false;
        }

        if (other.CompareTag("DialogueTrigger"))
        {
            dialogueManager.StartDialogue(dialogue);
        }
    }
}
