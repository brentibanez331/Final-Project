using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour
{
    [SerializeField] private Material dissolveMat;
    private float dissolveAmount = 0;
    public bool isDissolving;
    private float dissolveSpeed = 3f;

    [HideInInspector] public bool swordTouched = false;

    GameObject player;
    [SerializeField] float followSpeed = 3f;
    float xPosOffset = 0.7f;
    Vector3 newPos;

    bool followPlayer = false;

    Animator anim;

    [SerializeField] ParticleSystem idleParticles;
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "MapDesign")
        {
            idleParticles.Stop();
            followPlayer = true;
        }

        dissolveMat.SetFloat("_DissolveAmount", dissolveAmount);
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim.SetBool("isRotating", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            anim.enabled = false;

            if (player.transform.localScale.x == 1)
            {
                newPos = new Vector3(player.transform.position.x + xPosOffset * -1, player.transform.position.y + 0.3f, -0.2f);
            }
            else
            {
                newPos = new Vector3(player.transform.position.x + xPosOffset, player.transform.position.y + 0.3f, -0.2f);
            }

            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

            if (isDissolving)
            {
                dissolveAmount = Mathf.Clamp(dissolveAmount + dissolveSpeed * Time.deltaTime, 0, 1.1f);
                dissolveMat.SetFloat("_DissolveAmount", dissolveAmount);
            }
            else
            {
                dissolveAmount = Mathf.Clamp(dissolveAmount - dissolveSpeed * Time.deltaTime, 0, 1.1f);
                dissolveMat.SetFloat("_DissolveAmount", dissolveAmount);
            }
        }
    }

    public void Dissolving()
    {
        isDissolving = true;
    }

    public void Regaining()
    {
        isDissolving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            swordTouched = true;
            followPlayer = true;
            idleParticles.Stop();
            transform.localRotation = Quaternion.identity;
            anim.SetBool("isRotating", false);
        }
    }
}
