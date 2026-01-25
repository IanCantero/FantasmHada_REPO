using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwapper : MonoBehaviour
{
  void  OnTriggerEnter2D(Collider2D other)
  {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }
  }

  IEnumerator LoadNextScene()
  {
        yield return StartCoroutine(FadeManager.Instance.FadeOut());
        SceneManager.LoadScene(5);
  }
}
