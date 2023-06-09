using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    //[SerializeField] public Slider slider;

    [SerializeField] public Image expFill;

    [HideInInspector] public bool isLevel2 = false;

    [SerializeField] LevelSystemAnimated levelSystemAnimated;
    [SerializeField] LevelSystem levelSystem;

    [SerializeField] public TextMeshProUGUI levelText;

    StatePreserve statePreserve;
    DefaultState defaultState;

    private void Start()
    {
        statePreserve = GameObject.FindGameObjectWithTag("StatePreserve").GetComponent<StatePreserve>();

        levelText.text = statePreserve.level.ToString();

        expFill.fillAmount = 0f;
        SetLevelSystemAnimated();
    }

    private void Update()
    {
        //Debug.Log(levelSystem.GetLevelNumber());

        if(expFill.fillAmount >= 1f)
        {
            levelText.text = levelSystem.GetLevelNumber().ToString();
            if(levelText.text == "2")
            {
                isLevel2 = true;
            }
        }
    }

    public void SetExp(float expNormalized)
    {
        expFill.fillAmount = expNormalized;
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
