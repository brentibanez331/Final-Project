using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    private LimitArea limitArea;
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject earthBoss;
    void Awake()
    {
        limitArea = GetComponent<LimitArea>();
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            EarthBossScript earthBossScript = earthBoss.GetComponent<EarthBossScript>();
            earthBossScript.SetPlayerHasEntered(true);
            StartCoroutine(InitiateBarrier()); //function that starts when player enters the collider
        }
    }
    IEnumerator InitiateBarrier()
    {
        yield return new WaitForSeconds(1f);
        InstantiateBarrier(); //function to instantiate a barrier to prevent player from leaving
    }
    void InstantiateBarrier()
    {
        limitArea.InstantiateBarrier(barrier);
    }
}
