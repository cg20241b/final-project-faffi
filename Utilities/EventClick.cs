using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // For pointer events
using UnityEngine.SceneManagement; // For loading scenes

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource clickSFX;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSFX != null)
        {
            clickSFX.Play();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider is SphereCollider)
            {
                string planetName = hit.collider.gameObject.name;
                Debug.Log($"Clicked on: {planetName}");

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
                        Debug.LogWarning("No scene mapped for this planet!");
                        break;
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Empty
    }
}