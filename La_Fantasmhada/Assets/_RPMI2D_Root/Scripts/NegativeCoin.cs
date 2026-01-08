using UnityEngine;

public class NegativeCoin : MonoBehaviour
{
    [SerializeField] int minusHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Se accede a la vida en el GameManager, se resta y luegos se apaga la moneda
            GameManager.Instance.playerHealth -= minusHealth;
            gameObject.SetActive(false);
        }

    }
}
