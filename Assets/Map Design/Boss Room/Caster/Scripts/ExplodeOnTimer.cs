using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTimer : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject explosionCollider;
    

    public bool timerStarts = false;
    private float timer = .9f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Debug.Log(timer);
        if (timerStarts)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            Explode();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {           
            timerStarts = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //Debug.Log(timer);
        }
    }
    void Explode()
    {
        //Debug.Log("Instantiate");
        ParticleSystem instantiatedExplosion = Instantiate(explosion, transform.localPosition, transform.rotation);

        GameObject explodeColliderObject = Instantiate(explosionCollider, Vector3.zero, instantiatedExplosion.transform.localRotation);
        explodeColliderObject.transform.SetParent(instantiatedExplosion.transform, false);

        Destroy(instantiatedExplosion.gameObject, .4f);
        timer = .9f;
        timerStarts = false;
    }
}
