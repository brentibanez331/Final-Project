using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAbility : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;

    [SerializeField] GameObject hitImpact;
    Vector3 offset = new Vector3(0.2f, 0.2f, 0);

    float scaleSpeed = 2f;

    float timeRemaining = 5f;
    float scale = 0.2f;

    float direction;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.localScale.x;

        if(direction == -1)
        {
            offset = new Vector3(-0.2f, 0.2f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        
        scale = Mathf.Clamp01(scale + scaleSpeed * Time.deltaTime);

        transform.localScale = new Vector2(scale * direction, scale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Instantiate(hitImpact, transform.position + offset, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.tag == "Ground")
        {
            Instantiate(hitImpact, transform.position + offset, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Debug.Log("You hit ground");
        }
    }
}
