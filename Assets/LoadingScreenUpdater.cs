using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenUpdater : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image slider;

    [SerializeField] Sprite Aeris;
    [SerializeField] Sprite Terraria;
    [SerializeField] Sprite Hydris;
    [SerializeField] Sprite Pyroterra;

    [SerializeField] SceneHandler sceneHandler;
    [SerializeField] string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        slider.fillAmount = 0f;
        image.sprite = Aeris;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.fillAmount < 1f)
        {
            if(slider.fillAmount < 0.25f)
            {
                image.sprite = Aeris;
            }

            if(slider.fillAmount > 0.25f && slider.fillAmount < 0.50f)
            {
                image.sprite = Terraria;
            }

            if (slider.fillAmount > 0.50f && slider.fillAmount < 0.75f)
            {
                image.sprite = Hydris;
            }

            if (slider.fillAmount > 0.75f)
            {
                image.sprite = Pyroterra;
            }

            slider.fillAmount = Mathf.MoveTowards(slider.fillAmount, 1f, 0.1f * Time.deltaTime);
        }

        if(slider.fillAmount >= 1f)
        {
            sceneHandler.StartFade(sceneName);
        }
    }
}
