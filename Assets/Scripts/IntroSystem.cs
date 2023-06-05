using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntroSystem : MonoBehaviour
{
    GameObject player;
    [HideInInspector] public Animator playerAnim;

    [HideInInspector] public bool isWalking = true;
    [HideInInspector] public bool canvasRegaining = false;

    [SerializeField] float speed = 5f;

    [SerializeField] GameObject cameraObject;
    Animator camObjAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        player.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.SetBool("isWalking", true);
        camObjAnimator = cameraObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            player.GetComponent<PlayerMovement>().walkSFX.enabled = true;
            player.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DialogueTrigger")
        {
            isWalking = false;
            playerAnim.SetBool("isWalking", false);
            camObjAnimator.SetTrigger("panRight");
        }
        if(collision.tag == "Sword")
        {
            //dialogueTrigger.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerCombat>().enabled = true;
            isWalking = false;
            canvasRegaining = true;
        }
    }
}
