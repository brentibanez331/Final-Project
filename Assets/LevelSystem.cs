using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] int level = 1;
    [SerializeField] float currentExp = 0;
    [SerializeField] float requiredExp = 500;
    float previousExp = 0;

    float timeRemaining = 0.5f;

    [SerializeField] float expRate;

    [SerializeField] ExperienceBar expBar;

    void Start()
    {
        expBar.SetMaxExp(currentExp, requiredExp);
    }

    public void GainExp(float expValue)
    {
        if(timeRemaining == 0.5f)
        {
            previousExp = currentExp;              //if time remaining = 0.5, run this, subtract from the variable to prevent updating
            StartCoroutine(Timer());
        }
        currentExp = currentExp + expValue;

        if(currentExp > requiredExp)
        {
            level++;
            currentExp = currentExp - requiredExp;
            requiredExp = requiredExp + (requiredExp * (expRate/100));
            previousExp = 0;
            expBar.SetMaxExp(currentExp, requiredExp);
            //StartCoroutine(Timer());
            //expBar.SetExp(previousExp, currentExp, requiredExp);
        }

       // Debug.Log("Your current exp is: " + currentExp);
        //Debug.Log("Your required exp is: " + requiredExp);
    }

    IEnumerator Timer()
    {
        while(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            yield return null;
        }
        expBar.SetExp(previousExp, currentExp, requiredExp);
        timeRemaining = 0.5f;
    }
}
