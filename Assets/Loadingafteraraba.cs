using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadingafteraraba : MonoBehaviour
{
    void Start()
    {
        // 10 saniye sonra LoadNextScene fonksiyonunu �a��r
        Invoke("LoadNextScene", 4f);
    }

    void LoadNextScene()
    {
        // "Scene2" sahnesini y�kle
        SceneManager.LoadScene("EvIlk");
    }
}
