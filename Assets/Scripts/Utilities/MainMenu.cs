using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource uiClickSFX;

    public void PlayGame()
    {
        if (uiClickSFX != null)
        {
            uiClickSFX.Play();
            StartCoroutine(WaitAndLoadScene("SolarSystem", uiClickSFX.clip.length));
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SolarSystem");
        }
    }

    public void ExitGame()
    {
        if (uiClickSFX != null)
        {
            uiClickSFX.Play();
            StartCoroutine(WaitAndQuit(uiClickSFX.clip.length));
        }
        else
        {
            Application.Quit();
        }
    }

    private System.Collections.IEnumerator WaitAndLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private System.Collections.IEnumerator WaitAndQuit(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}