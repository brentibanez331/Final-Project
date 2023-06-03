using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdater : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;

    [SerializeField] bool lookDown;

    [SerializeField] Transform platformLook;
    Transform player;

    //[SerializeField] Vector3 offset;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if (lookDown)
            {
                _virtualCamera.Follow = platformLook;
            }
            //_virtualCamera.Follow = platformLook;
            //Debug.Log(platformLook.position);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (lookDown)
            {
                _virtualCamera.Follow = player;
            }
            //_virtualCamera.Follow = platformLook;
            //Debug.Log(platformLook.position);
        }
    }
}
