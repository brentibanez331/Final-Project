using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxUpdater3 : MonoBehaviour
{
    [SerializeField] Transform peakPoint;
    GameObject player;
    Animator anim;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [SerializeField] DialogueManager dialogueManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.sentences.Count > 0)
        {
            virtualCamera.Follow = peakPoint;

            anim.SetBool("isWalking", false);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerCombat>().enabled = false;
        }
        else
        {
            if (dialogueManager.dialogueEnded)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                player.GetComponent<PlayerCombat>().enabled = true;
                virtualCamera.Follow = player.transform;
                dialogueManager.dialogueEnded = false;
            }
            
        }
    }
}
