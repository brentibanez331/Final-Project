using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updater : MonoBehaviour
{
    public Image fireBallUI;
    public Image frostBiteUI;
    public Image zephyrShieldUI;
    public Image aquaPulseUI;

    GameObject statePreserve;

    // Start is called before the first frame update
    void Start()
    {
        statePreserve = GameObject.FindGameObjectWithTag("StatePreserve");

        fireBallUI.sprite = statePreserve.GetComponent<StatePreserve>().fireball;
        frostBiteUI.sprite = statePreserve.GetComponent<StatePreserve>().frostbite;
        zephyrShieldUI.sprite = statePreserve.GetComponent<StatePreserve>().zephyr;
        aquaPulseUI.sprite = statePreserve.GetComponent<StatePreserve>().aquapulse;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
