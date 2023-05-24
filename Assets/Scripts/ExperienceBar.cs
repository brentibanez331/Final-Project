using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] public Slider slider;

    //[SerializeField] LevelSystem levelSystem;
    [SerializeField] LevelSystemAnimated levelSystemAnimated;

    private void Start()
    { 
        SetLevelSystemAnimated();
    }
    public void SetExp(float expNormalized)
    {
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
