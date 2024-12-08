using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.Self);
    }
}