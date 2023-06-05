using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProjectile : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float projectileSpeed = 10f;

    [SerializeField] private Transform[] projectileLocation; //array of projectile spawner location
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private ParticleSystem gatheringParticle;


    private bool instantiatedPrefab; //determines if projectile is instantiated
    private bool instatiantedParticle; //determines if particle is instantiated

    [SerializeField] AudioSource rockSFX;

    public IEnumerator ProjectileGenerator()
    {
        yield return new WaitForSeconds(1f);
        if (!instatiantedParticle) // instantiates projectile
        {
            foreach (Transform projectileLoc in projectileLocation)
            {
                ParticleSystem particle = Instantiate(gatheringParticle, projectileLoc.position, projectileLoc.rotation);
                instatiantedParticle = true;
                Destroy(particle.gameObject, 1f);
            }
        }
        yield return new WaitForSeconds(1f);
        if (!instantiatedPrefab) // instantiates particle
        {
            rockSFX.Play();
            foreach (Transform projectileLoc in projectileLocation)
            {
                GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, projectileLoc.position, projectileLoc.rotation);
                Projectile projectile = projectileGO.GetComponent<Projectile>();
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce(projectileLoc.up * projectileSpeed, ForceMode2D.Impulse);
                instantiatedPrefab = true;              
                //projectile.SetTarget(target); //function that sets the target from this script to the projectile script             
            }
            yield return new WaitForSeconds(4f);
            instatiantedParticle = false;
            yield return new WaitForSeconds(1f);
            instantiatedPrefab = false;
        }
    }
}
