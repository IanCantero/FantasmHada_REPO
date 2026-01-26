using UnityEngine;
using System.Collections;


public class EnemyBrain : MonoBehaviour
{
    [Header("Attack Configuration")]
    bool canAttack = true;
    [SerializeField] float attackCooldown = 2f;

 

    [Header("Movement")]
    [SerializeField] float speed = 3f;
    [SerializeField] float stopDistance = 0.8f;

    [Header("Target")]
    [SerializeField] Transform player;

    Rigidbody2D rb;

    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        float distanceX = player.position.x - transform.position.x;

        if (Mathf.Abs(distanceX) > stopDistance)
        {
            float dir = Mathf.Sign(distanceX);
            rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);

            animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetFloat("Speed", 0);
            if (canAttack)
            {
                StartCoroutine(Attack());
            }
        }
    } 

    void Update()
    {
        // Girar sprite
        if (player == null) return;

        Vector3 scale = transform.localScale;
        scale.x = player.position.x > transform.position.x ? 1 : -1;
        transform.localScale = scale;
    }

    IEnumerator Attack()
    {
        canAttack = false;
        animator.SetTrigger("Attack");
        AudioManager.Instance.PlaySFX(3);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        yield return null;
    }
    
   

    public void SetTarget(Transform newTarget)
    {
        player = newTarget;
    }

}
