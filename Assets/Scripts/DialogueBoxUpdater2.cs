using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxUpdater2 : MonoBehaviour
{
    [SerializeField] Transform peakPoint;
    Transform player;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [SerializeField] DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.sentences.Count == 2)
        {
            virtualCamera.Follow = peakPoint;
        }
        if(dialogueManager.sentences.Count == 0)
        {
            virtualCamera.Follow = player;
        }
    }
}
