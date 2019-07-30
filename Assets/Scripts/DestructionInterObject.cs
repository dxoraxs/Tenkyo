using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructionInterObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Debug.Log("Start Coroutine");
        yield return new WaitForSeconds(2);
        RestartScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
