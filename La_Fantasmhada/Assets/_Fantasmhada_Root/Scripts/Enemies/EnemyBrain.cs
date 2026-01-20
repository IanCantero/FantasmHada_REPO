using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject targetToFollow;
    bool isPlayerOnRange;
    bool isPlayerOnVision;
    Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      isPlayerOnRange = false;
      isPlayerOnVision = false;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void EnemyTracker()
    {
        if (isPlayerOnRange)
        {
            anim.SetBool("Run", true);
            Vector2 vector2 = targetToFollow.transform.position;
        }

        void OnTriggerEnter2D()
        {
            if (other.compareTag("Player"))
            {
                isPlayerOnVision = true;
            }
        }
    }
}
