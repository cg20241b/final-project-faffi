using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float pitchPower = 50f;  // Scaled for smoother and more responsive pitch control
    public float rollPower = 50f;  // Scaled for smoother roll control
    public float yawPower = 40f;   // Scaled for yaw control to keep it manageable
    public float accelerationSpeed = 10f; // Faster acceleration
    public float decelerationSpeed = 5f;  // Slightly slower deceleration
    public float maxEnginePower = 125f;   // New max engine power

    private float currentEnginePower;
    private float activeRoll, activePitch, activeYaw;

    private void Update()
    {
        // Throttle Handling (Smooth Acceleration/Deceleration)
        if (Input.GetKey(KeyCode.Space))
        {
            currentEnginePower = Mathf.Lerp(currentEnginePower, maxEnginePower, accelerationSpeed * Time.deltaTime);
        }
        else
        {
            currentEnginePower = Mathf.Lerp(currentEnginePower, 0, decelerationSpeed * Time.deltaTime);
        }

        // Forward Movement
        transform.position += transform.forward * currentEnginePower * Time.deltaTime;

        // Input Handling (No Unnecessary Smoothing)
        float pitchInput = Input.GetAxis("Vertical");
        float rollInput = Input.GetAxis("Horizontal");
        float yawInput = GetYawInput();

        // Apply Rotation
        activePitch = pitchInput * pitchPower;
        activeRoll = rollInput * rollPower;
        activeYaw = yawInput * yawPower;

        transform.Rotate(activePitch * Time.deltaTime, activeYaw * Time.deltaTime, -activeRoll * Time.deltaTime, Space.Self);
    }

    private float GetYawInput()
    {
        float yawInput = 0;
        if (Input.GetKey(KeyCode.Q)) yawInput = -1;
        if (Input.GetKey(KeyCode.E)) yawInput = 1;
        return yawInput;
    }
}
