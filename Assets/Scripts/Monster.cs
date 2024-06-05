using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the GameObject movement along the X-axis
    public AudioClip jumpScareSound; // The jump scare sound clip
    public float jumpScareThreshold = 10.0f; // The X position at which the jump scare will trigger

    private AudioSource audioSource;
    private bool jumpScarePlayed = false;

    void Start()
    {
        // Get the AudioSource component or add one if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the jump scare sound to the AudioSource
        audioSource.clip = jumpScareSound;
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
                PlayJumpScare();
            }
        }


    }

    void PlayJumpScare()
    {
        // Play the jump scare sound
        audioSource.Play();
        jumpScarePlayed = true; // Ensure the jump scare only plays once
    }
}
