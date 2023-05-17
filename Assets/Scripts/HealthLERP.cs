using UnityEngine;
using UnityEngine.UI;

public class HealthLERP : MonoBehaviour
{
    public Slider slider;

    [HideInInspector]
    public bool takenDamage = false;

    public HealthBar healthbar;

    float speed = 2f;

    void Update()
    {
        //slider.maxValue = healthbar.maxHealth;
        if (takenDamage)
        {
            slider.value = Mathf.Lerp(slider.value, healthbar.currentHealth, Time.deltaTime * speed);
        }
        else
        {
            slider.value = slider.value;
        }

        if(slider.value == healthbar.currentHealth)
        {
            takenDamage = false;
        }
        
       // slider.value = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
