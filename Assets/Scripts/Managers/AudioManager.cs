using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip arabaClip;
    [SerializeField] AudioSource audioSource;


    // Static instance of the class.
    private static AudioManager _instance;
    // Public static property to access the instance.



    //SIGLETON PATTERN
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find an existing instance of the singleton in the scene.
                _instance = FindObjectOfType<AudioManager>();

                if (_instance == null)
                {
                    // Create a new GameObject if an instance does not already exist.
                    GameObject singletonObject = new GameObject(typeof(LanternLight).ToString());
                    _instance = singletonObject.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy the new instance.
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Make sure the instance is not destroyed on scene load.
        }
    }

    public void playAudioCar()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = arabaClip;
        audioSource.Play();
    }
}
