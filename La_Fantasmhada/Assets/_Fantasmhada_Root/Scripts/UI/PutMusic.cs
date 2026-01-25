using UnityEngine;

public class PutMusic : MonoBehaviour
{
    
    public int musicToPlay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayMusic(musicToPlay);
    }
}
