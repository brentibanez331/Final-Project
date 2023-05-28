using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public int previousHealth;

    [HideInInspector]
    public int maxHealth;

    [SerializeField] Image hpFill;

    [SerializeField] PlayerHealthDamp playerHpDamp;

    public void SetHealth(int currHealth, int max_Health)
    {
        playerHpDamp.takenDamage = true;

        hpFill.fillAmount = (float) currHealth/max_Health;
        currentHealth = currHealth;
        maxHealth = max_Health;
    }
}
