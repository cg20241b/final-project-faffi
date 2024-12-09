using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Include TextMeshPro namespace

public class SpaceshipRadiusHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    private float timeInCollider = 0f;
    private bool isInCollider = false;
    private string planetName;
    private Coroutine sceneLoadCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            planetName = gameObject.name;
            DisplayMessage($"You are entering {planetName}'s radius");

            isInCollider = true;

            if (sceneLoadCoroutine == null)
            {
                sceneLoadCoroutine = StartCoroutine(HandleSceneLoad());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            DisplayMessage($"You left {planetName}'s radius");

            isInCollider = false;
            timeInCollider = 0f;

            if (sceneLoadCoroutine != null)
            {
                StopCoroutine(sceneLoadCoroutine);
                sceneLoadCoroutine = null;
            }
        }
    }

    private IEnumerator HandleSceneLoad()
    {
        while (isInCollider)
        {
            timeInCollider += Time.deltaTime;

            if (timeInCollider >= 0.5f)
            {
                DisplayMessage($"Loading scene for {planetName}");

                // Load the corresponding scene
                switch (planetName)
                {
                    case "Sun":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("SunInspect");
                        break;
                    case "Mercury":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("MercuryInspect");
                        break;
                    case "Venus":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("VenusInspect");
                        break;
                    case "Earth":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("EarthInspect");
                        break;
                    case "Mars":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("MarsInspect");
                        break;
                    case "Jupiter":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("JupiterInspect");
                        break;
                    case "Saturn":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("SaturnInspect");
                        break;
                    case "Uranus":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("UranusInspect");
                        break;
                    case "Neptune":
                        UnityEngine.SceneManagement.SceneManager.LoadScene("NeptuneInspect");
                        break;
                    default:
                        DisplayMessage($"No scene mapped for {planetName}!");
                        break;
                }
                yield break;
            }

            yield return null;
        }
    }

    private void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }
}
