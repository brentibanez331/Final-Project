using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBoxUpdater : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite kaidoSprite;
    string playerName = "AERIS";
    string kaidoName = "KAIDO";

    [SerializeField] GameObject introManager;
    GameObject player;

    [SerializeField] DialogueManager dialogueManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.sentences.Count == 9 || dialogueManager.sentences.Count == 5)
        {
            dialogueManager.nameText.SetText(playerName);
            image.sprite = playerSprite;
        }
        else
        {
            dialogueManager.nameText.SetText(kaidoName);
            image.sprite = kaidoSprite;
        }

        if(dialogueManager.sentences.Count == 1)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerMovement>().walkSFX.enabled = true;
            Destroy(gameObject);
            Destroy(introManager);
        }
    }
}
