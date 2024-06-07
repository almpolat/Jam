using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Start1()
    {
        SceneManager.LoadScene("Araba");
    }
    public void Restart1()
    {
        SceneManager.LoadScene("Menü");
    }

    public void RestartCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
