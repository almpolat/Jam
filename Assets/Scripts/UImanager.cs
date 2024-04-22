using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject PauseCanvas = null;

    public void SetActivePause(bool state)
    {
        PauseCanvas.SetActive(state);
        Time.timeScale = state ? 0 : 1;
        isPaused = state;
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            SetActivePause(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            SetActivePause(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
