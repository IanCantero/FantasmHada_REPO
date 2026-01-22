using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] float damageAmount = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Golpeó al jugador");
            GameManager.Instance.takeDamage(damageAmount);
           // gameObject.SetActive(false);
        }

    }
}
