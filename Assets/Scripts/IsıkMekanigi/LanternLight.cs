using System.Collections;
using UnityEngine;

public class LanternLight : MonoBehaviour
{


    // Static instance of the class.
    private static LanternLight _instance;
    // Public static property to access the instance.

    //SIGLETON PATTERN
    public static LanternLight Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find an existing instance of the singleton in the scene.
                _instance = FindObjectOfType<LanternLight>();

                if (_instance == null)
                {
                    // Create a new GameObject if an instance does not already exist.
                    GameObject singletonObject = new GameObject(typeof(LanternLight).ToString());
                    _instance = singletonObject.AddComponent<LanternLight>();
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


    [SerializeField] public bool isRemainingTimeFinished;
    [SerializeField] private bool isOffsetTimeFinished;
    [SerializeField] public bool isRefreshed;
    [SerializeField] private int offsetTime;

    [SerializeField] private GameObject Lantern;
    public bool isLanternActive;

    //Scale will used in diffrent classes.
    public float lightScale;
    [SerializeField] private float lightTime;




    private void Start()
    {

        //StartCoroutine(ligtMeter());

        isLanternActive = false;
    }

    private void Update()
    {
        if (Lantern.activeInHierarchy && isLanternActive)
        {
            StartCoroutine(test());


        }
    }

    IEnumerator test()
    {
        while (true)
        {
            isLanternActive = false;
            //Reset time & scale
            float duration = 0;
            lightScale = 30;

            //Countdown 
            for (float i = lightTime; i > 0; i -= 0.1f)
            {
                if (!isRefreshed)
                {
                    yield return new WaitForSeconds(0.1f);

                    lightScale -= 0.1f;
                    duration += 0.1f;

                    isRemainingTimeFinished = true;

                    Debug.Log("scale : " + lightScale + " duration : " + duration);
                }
                else
                {
                    break;
                }

            }
            //Debug.Log("for loop finished in : " + duration + "seconds " + " scale :  "+ lightScale);
            yield return null;
        }
    }
    IEnumerator ligtMeter()
    {
        while (true)
        {
            if (isRefreshed)
            {


                if (isOffsetTimeFinished!)
                {
                    if (offsetTime > 0)
                    {
                        //Offset time reducing
                        for (int i = offsetTime; i > 0; i--)
                        {
                            yield return new WaitForSeconds(1);
                            Debug.Log("ofsetTime : " + isOffsetTimeFinished);
                        }
                    }

                    else
                    {
                        isOffsetTimeFinished = true;
                    }
                }


                else if (isOffsetTimeFinished)
                {
                    //Wait time reducing
                    for (float i = lightTime; i > 0; i -= 0.1f)
                    {
                        yield return new WaitForSeconds(0.1f);
                        lightScale -= 0.1f;
                        isRemainingTimeFinished = true;
                        Debug.Log("remainingTime : " + lightTime);
                    }
                }



            }


            else
            {
                yield return null;
            }

            yield return null;
        }


    }

}
