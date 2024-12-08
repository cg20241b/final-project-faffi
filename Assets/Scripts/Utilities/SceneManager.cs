using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Button backButton;
    public AudioSource uiClickSFX;

    void Start()
    {
        backButton.onClick.AddListener(BackToRoaming);
    }

    void BackToRoaming()
    {
        if (uiClickSFX != null)
        {
            uiClickSFX.Play();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("SolarSystem");
    }
}
