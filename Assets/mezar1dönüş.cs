using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mezar1dönüş : MonoBehaviour
{
    void Start()
    {
        // 10 saniye sonra LoadNextScene fonksiyonunu çağır
        Invoke("LoadNextScene", 4f);
    }

    void LoadNextScene()
    {
        // "Scene2" sahnesini yükle
        SceneManager.LoadScene("EvIkıncı");
    }
}
