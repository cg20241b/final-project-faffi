using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float rotationSpeed = 0.0001543f;
    public float tiltAngle = 7.25f;

    private Quaternion tiltRotation;

    void Start()
    {
        tiltRotation = Quaternion.Euler(tiltAngle, 0f, 0f);
    }

    void Update()
    {
        transform.rotation = tiltRotation * Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}