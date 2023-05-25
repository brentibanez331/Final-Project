using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] public Slider slider;

    [SerializeField] LevelSystemAnimated levelSystemAnimated;

    private void Start()
    {
        slider.minValue = 0;
        slider.value = 0;
        slider.maxValue = 1;
        SetLevelSystemAnimated();
        //Debug.Log("Experience Bar");
    }

    /*ExperienceBar()
    {
        SetLevelSystemAnimated();
    }*/

    //Gubaon ka
    public void SetExp(float expNormalized)
    {
        slider.maxValue = 1;
        //Debug.Log(expNormalized);
        slider.value = expNormalized;
    }
    public void SetLevelSystemAnimated()
    {
        SetExp(levelSystemAnimated.GetExpNormalized());

        levelSystemAnimated.OnExperienceChanged += LevelSystemAnimated_OnExperienceChanged;
    }

    private void LevelSystemAnimated_OnExperienceChanged(object sender, System.EventArgs e)
    {
        SetExp(levelSystemAnimated.GetExpNormalized()); ;
    }
}
