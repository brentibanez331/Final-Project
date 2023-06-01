using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageProjectile : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    private void Start()
    {
        StartCoroutine(scaleOverTime(this.transform, new Vector3(.3f, .3f, .3f), 2f));
    }
    void FixedUpdate()
    {
        RotateProjectile();
    }
    void RotateProjectile()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration) 
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration); //scales the gameobject over time
            yield return null;
        } 
    }
}
