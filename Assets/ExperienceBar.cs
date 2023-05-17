using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    float lerpDuration = 1;

    private void Update()
    {

    }

    public void SetMaxExp(float currentExp, float requiredExp)
    {
        slider.value = currentExp/requiredExp;
    }

    public void SetExp(float previousExp, float currentExp, float requiredExp)
    {
        //prevExp = previousExp;
        //currExp = currentExp;
        //reqExp = requiredExp;
        StartCoroutine(Lerp(previousExp, currentExp, requiredExp));
        //slider.value = currentExp / requiredExp;
    }


    IEnumerator Lerp(float prevExp, float currExp, float reqExp)
    {
        float timeElapsed = 0;
        while(timeElapsed < lerpDuration)
        {
            slider.value = Mathf.Lerp(prevExp/reqExp, currExp/reqExp, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        slider.value = currExp/reqExp;
    }
}
