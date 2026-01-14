using UnityEngine;
using UnityEngine.UI;

public class HealhUI : MonoBehaviour
{
    [SerializeField] Image healthFill;


    // Update is called once per frame
    void Update()
    {
        healthFill.fillAmount = GameManager.Instance.playerHealth / GameManager.Instance.maxHealth;
    }
}
