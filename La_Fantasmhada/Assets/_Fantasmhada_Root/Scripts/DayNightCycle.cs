using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{

    [Header("Day Night Cycle Settings")]

    public Light2D globalLight;

    [SerializeField] float cycleDuration = 120f;
    [SerializeField] Color morningColor;
    [SerializeField] Color dayColor;
    [SerializeField] Color eveningColor;
    [SerializeField] Color nightColor;

    float time;
    float t;

    [Header("Player Swap Settings")]

    [SerializeField] GameObject dayPlayer;
    [SerializeField] GameObject nightPlayer;
    bool isNightPlayerActive;

    [Header("EnemySpawn Settings")]
    [SerializeField] GameObject enemySpawner;

    [Header("NPC Spawn Settings")]
    [SerializeField] GameObject npcDespawner;
    [SerializeField] GameObject vasyr;

    [Header("Scene Loader Settings")]
    [SerializeField] GameObject sceneLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayPlayer.SetActive(true);
        nightPlayer.SetActive(false);
        isNightPlayerActive = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        time += Time.deltaTime;
        t = time  / cycleDuration;
        DayPhases();
        PlayerSwitch();
    }

    void PlayerSwitch()
    {
        if (t >= 0.75f && !isNightPlayerActive)
        {
            nightPlayer.transform.position = dayPlayer.transform.position;
            nightPlayer.transform.rotation = dayPlayer.transform.rotation;
            dayPlayer.SetActive(false);
            nightPlayer.SetActive(true);
            isNightPlayerActive = true;
            enemySpawner.SetActive(true);
            npcDespawner.SetActive(false); 
            vasyr.SetActive(true);
            sceneLoader.SetActive(true);
        }
    }

    void DayPhases()
    {
        if (t < 0.25f)
        {
            globalLight.color = Color.Lerp(morningColor, dayColor, t / 0.25f);
        }
        else if (t < 0.5f)
        {
            globalLight.color = Color.Lerp(dayColor, eveningColor, (t - 0.25f) / 0.25f);

        }
        else if (t < 0.75f)
        {
            globalLight.color = Color.Lerp(eveningColor, nightColor, (t - 0.50f) / 0.25f);

        }
        else
        {
            globalLight.color = Color.Lerp(nightColor, morningColor, (t - 0.75f) / 0.25f);

        }
    }
}
