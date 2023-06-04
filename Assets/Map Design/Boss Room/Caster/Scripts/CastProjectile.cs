using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastProjectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private float[] positionMultiplier = { -2f, 0f, 2f };
    public float addRotation = 10f;


    public void Cast(GameObject projectile)
    {
        for(int i = 0; i < 3; i++)
        {
            Vector3 position = new Vector3(positionMultiplier[i], 0f, 0f);
            Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + addRotation);

            GameObject instantiatedProjectile = Instantiate(projectile, transform.position + position, transform.rotation * rotation);
            Rigidbody2D rb = instantiatedProjectile.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);

            Destroy(instantiatedProjectile, 1.3f);
        }
    }
}
