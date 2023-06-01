using UnityEngine;

public class SnailProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float projectileSpeed = 5f;
    private float timer;
    private float duration = 5f;
    //[SerializeField] private 

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
        timer = duration - Time.fixedDeltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
            duration = 5f;
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
