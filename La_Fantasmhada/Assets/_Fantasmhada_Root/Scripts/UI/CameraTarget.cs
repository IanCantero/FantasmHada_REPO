using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Transform dayPlayer;
    [SerializeField] Transform nightPlayer;

    void LateUpdate()
    {
        if (dayPlayer.gameObject.activeInHierarchy)
            transform.position = dayPlayer.position;
        else if (nightPlayer.gameObject.activeInHierarchy)
            transform.position = nightPlayer.position;
    }
}
