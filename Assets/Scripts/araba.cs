using UnityEngine;

public class araba : MonoBehaviour
{
    public float speed = 10f; // Car movement speed

    private void Update()
    {
        // Get input from W key (forward movement)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(0f, 0f, 1f).normalized;

        // Move the car
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MezarlýkTrigger"))
        {
            Dialog.Instance.LoadAndStartDialog("araba");
        }
    }
}
