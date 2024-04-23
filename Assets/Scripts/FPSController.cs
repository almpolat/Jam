using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public bool isPaused = false;//Alimert
    public AudioSource walkAudioSource;//Alimert

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private bool isMoving;//Alimert

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        walkAudioSource = GetComponent<AudioSource>();//Alimert

        if (playerCamera == null)
        {
            Debug.LogError("FPS Controller requires a camera child object to function properly.");
        }
        if (walkAudioSource == null)//Alimert
        {
            Debug.LogError("No AudioSource component found on the object.");
        }
    }

    void Update()
    {
        if (isPaused) return;//Alimert
        // Rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        //Alimert
        characterController.SimpleMove(speed);
        isMoving = characterController.velocity.magnitude > 0;

        if (isMoving && !walkAudioSource.isPlaying)
        {
            walkAudioSource.Play();
        }
        else if (!isMoving && walkAudioSource.isPlaying)
        {
            walkAudioSource.Stop();
        }
    }
}
