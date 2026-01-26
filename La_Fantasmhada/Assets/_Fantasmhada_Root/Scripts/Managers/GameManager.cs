using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Declaración del Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) Debug.Log("No hay GameManager");
            return instance;
        }

    }
    //Fin del Singleton

    //DECLARAMOS CUALQUIER VALOR GENERAL EN PUBLIC
    public float playerHealth;
    public float maxHealth = 100;
    public int playerPoints;

    private void Awake()
    {
        if (instance == null)
        {
            //Si no hay GameManager lo referenciamos y hacemos que perdure entre escenas
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Si ya hay GameManager el duplicado se destruye
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerHealth = maxHealth;
        playerPoints = 0;
    }
    private void Update()
    {
        if (playerHealth < 0) playerHealth = 0;
        LoseGame();
    }

   public void takeDamage(float damage)
    {
        playerHealth -= damage;
    } 
    void LoseGame()
    {
        if (playerHealth == 0)
        {
            Debug.Log("Has perdido");
            SceneManager.LoadScene(7);
        }

    }

}
