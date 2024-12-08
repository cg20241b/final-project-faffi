using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed = 10f;         // Movement speed
    public float rotationSpeed = 100f; // Rotation speed

    void Update()
    {
        // Forward/backward movement
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);

        // Rotation
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }
}
