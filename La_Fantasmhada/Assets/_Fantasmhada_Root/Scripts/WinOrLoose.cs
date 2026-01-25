using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLoose : MonoBehaviour
{
    public int sceneNumber;   // Nombre de la escena a cargar
    private bool playerInside;

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            FadeManager.Instance.FadeOut();
            SceneManager.LoadScene(sceneNumber);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
