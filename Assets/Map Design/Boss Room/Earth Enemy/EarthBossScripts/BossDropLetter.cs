using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDropLetter : MonoBehaviour
{
    private GameObject EndDialogue;

    private bool onDialogue;

    private void Start()
    {
        EndDialogue = GameObject.FindGameObjectWithTag("Letter");
    }
    void Update()
    {
        if (onDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Scene to Main Menu");
                EndDialogue.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            EndDialogue.SetActive(true);
            onDialogue = true;
        }
    }
}
