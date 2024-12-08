using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoGeneratePlanet : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find all Planet objects in the newly loaded scene
        Planet[] planets = FindObjectsOfType<Planet>();

        foreach (Planet planet in planets)
        {
            planet.GeneratePlanet();
            Debug.Log($"Generating planet in scene: {scene.name}, Planet: {planet.name}");
        }

        if (planets.Length == 0)
        {
            Debug.Log($"No planets found in scene: {scene.name}");
        }
    }
}
