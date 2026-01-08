using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public Light2D globalLight;


    [SerializeField] float cycleDuration = 120f;
    [SerializeField] Color morningColor;
    [SerializeField] Color dayColor;
    [SerializeField] Color eveningColor;
    [SerializeField] Color nightColor;

    float time;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     time += Time.deltaTime;
        float t = time  / cycleDuration;

        if (t < 0.25f) 
        {
            globalLight.color = Color.Lerp(morningColor, dayColor, t/0.25f);
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
