using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthLERP hpLerp;

    public Slider slider;

    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public int previousHealth;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        hpLerp.slider.maxValue = health;
        hpLerp.slider.value = health;
    }

    public void SetHealth(int health)
    {
        hpLerp.takenDamage = true;

        slider.value = health;
        currentHealth = health;
    }
}
