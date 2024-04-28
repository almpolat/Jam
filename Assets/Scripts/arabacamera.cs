using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arabacamera : MonoBehaviour
{
    public float sensitivity = 2.0f; // Mouse sensitivity

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera based on mouse movement
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
    }
}
