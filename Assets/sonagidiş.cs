using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonagidiş : MonoBehaviour
{
    void Start()
    {
        // 10 saniye sonra LoadNextScene fonksiyonunu çağır
        Invoke("LoadNextScene", 4f);
    }

    void LoadNextScene()
    {
        // "Scene2" sahnesini yükle
        SceneManager.LoadScene("son");
    }
}
