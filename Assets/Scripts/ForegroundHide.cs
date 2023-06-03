using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundHide : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color color;

    bool isOpaque = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpaque)
        {
            //canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, 0.5f * Time.deltaTime);
            color.a = Mathf.Lerp(color.a, 0.4f, 4f * Time.deltaTime);
            spriteRenderer.color = color;
        }
        else
        {
            color.a = Mathf.Lerp(color.a, 1f, 4f * Time.deltaTime);
            spriteRenderer.color = color;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isOpaque = false;
        }
        if(collision.tag == "Enemy")
        {
            isOpaque = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOpaque = true;
        }
        if (collision.tag == "Enemy")
        {
            isOpaque = true;
        }
    }
}
