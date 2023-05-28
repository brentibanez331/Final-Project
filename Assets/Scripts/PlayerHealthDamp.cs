using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDamp : MonoBehaviour
{

    [SerializeField] Image hpFill;
    [SerializeField] PlayerHealthBar hpBar;

    [HideInInspector] public bool takenDamage = false;

    float healthNormalized;

    float speed = 0.5f;

    float velocity = 0.0f;

    float timeRemaining = 0.5f;

    // Update is called once per frame
    void Update()
    {
        healthNormalized = (float)hpBar.currentHealth / hpBar.maxHealth;

        if(takenDamage)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {

            }
            {
                hpFill.fillAmount = Mathf.MoveTowards(hpFill.fillAmount, healthNormalized, speed * Time.deltaTime);
                //hpFill.fillAmount = Mathf.SmoothDamp(hpFill.fillAmount, healthNormalized, ref velocity, speed * Time.deltaTime);
            }
        }
        else
        {
            hpFill.fillAmount = hpFill.fillAmount;
        }

        if (hpFill.fillAmount == healthNormalized)
        {
            if(timeRemaining < 0)
            {
                takenDamage = false;
                timeRemaining = 0.5f;
            }
            
        }
    }
}
