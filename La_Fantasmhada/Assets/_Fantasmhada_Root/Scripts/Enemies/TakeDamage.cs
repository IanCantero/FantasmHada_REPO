using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int actualHealth;
    public int maxHealth = 100;
    Collider2D col;
    Animator anim;
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualHealth = maxHealth;
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            actualHealth -= 50;
            if (actualHealth > 0)
            {
                anim.SetTrigger("Hit");
            }
            else
            {
                anim.SetTrigger("Death");
                col.enabled = false;
                GetComponent<EnemyBrain>().enabled = false;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

        }

    }
}
