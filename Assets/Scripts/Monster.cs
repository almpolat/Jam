using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the GameObject movement along the X-axis
    public AudioClip jumpScareSound; // The jump scare sound clip
    public AudioClip jumpScareSoundMusic;
    public float jumpScareThreshold = 10.0f; // The X position at which the jump scare will trigger

    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioSource audioSourceMusic;
    private bool jumpScarePlayed = false;

    [SerializeField] private GameObject MonsterObject;
    void Start()
    {
        // Get the AudioSource component or add one if it doesn't exist
        audioSourceSFX = GetComponent<AudioSource>();
        if (audioSourceSFX == null)
        {
            audioSourceSFX = gameObject.AddComponent<AudioSource>();
        }

        // Assign the jump scare sound to the AudioSource


    }

    void Update()
    {

        if (PlayerTriggers.Instance.isJumpscareCrossed)
        {
            // Move the GameObject along the X-axis
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Check if the GameObject's X position has reached the threshold for the jump scare
            if (!jumpScarePlayed)
            {

                //MonsterObject.GetComponent<Animator>().Play("IDOL");
                StartCoroutine(PlayJumpScareRoutine());

            }


        }


    }

    void PlayJumpScare()
    {

        audioSourceSFX.clip = jumpScareSound;
        audioSourceMusic.clip = jumpScareSoundMusic;

        // Play the jump scare sound
        audioSourceSFX.Play();
        audioSourceMusic?.Play();

    }

    IEnumerator PlayJumpScareRoutine()
    {
        // Ensure the jump scare only plays once
        jumpScarePlayed = true;
        PlayJumpScare();
        MonsterObject.SetActive(true);
        yield return new WaitForSeconds(jumpScareThreshold);
        MonsterObject.SetActive(false);
        jumpScarePlayed = true;


        yield return new WaitForSeconds(jumpScareThreshold);
        jumpScarePlayed = false;
    }
}
