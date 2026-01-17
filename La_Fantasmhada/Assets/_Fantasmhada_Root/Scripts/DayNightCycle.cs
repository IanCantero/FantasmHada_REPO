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
    private Color actualColor;

    float time;

    [Header("Player Swap Settings")]

    [SerializeField] GameObject dayPlayer;
    [SerializeField] GameObject nightPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayPlayer.SetActive(true);
        nightPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSwitch();
        time += Time.deltaTime;
        float t = time  / cycleDuration;

        if (t < 0.25f) 
        {
            globalLight.color = Color.Lerp(morningColor, dayColor, t/0.25f);
            actualColor = morningColor;
        }
        else if (t < 0.5f) 
        {
            globalLight.color = Color.Lerp(dayColor, eveningColor, (t - 0.25f) / 0.25f);
            actualColor = dayColor;
        }
        else if (t < 0.75f) 
        {
            globalLight.color = Color.Lerp(eveningColor, nightColor, (t - 0.50f) / 0.25f);
            actualColor = eveningColor;
        }
        else 
        {
            globalLight.color = Color.Lerp(nightColor, morningColor, (t - 0.75f) / 0.25f);
            actualColor = nightColor;
        }
    }

    void PlayerSwitch()
    {
        if (actualColor == nightColor)
        {
            nightPlayer.transform.position = dayPlayer.transform.position;
            nightPlayer.transform.rotation = dayPlayer.transform.rotation;
            dayPlayer.SetActive(false);
            nightPlayer.SetActive(true);
        }
    }
}
