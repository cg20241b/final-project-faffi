using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [System.Serializable]
    public class CelestialBody
    {
        public string name;          // Name of the body (e.g., Sun, Mercury)
        public Transform transform;  // Transform of the body
        public float rotationPeriod; // Rotation period in Earth hours
        public bool retrograde;      // Is the rotation retrograde?
        public float tiltAngle;      // Tilt angle in degrees (Sun or Uranus, e.g.)
    }

    public CelestialBody sun;       // The Sun
    public CelestialBody[] planets; // Planets array
    public float timeScale = 1000f; // Scaling for visibility
    
    void Update()
    {
        // Rotate the Sun
        if (sun.transform != null)
        {
            RotateBody(sun);
        }

        // Rotate each planet
        foreach (var planet in planets)
        {
            if (planet.transform != null)
            {
                RotateBody(planet);
            }
        }
    }

    private void RotateBody(CelestialBody body)
    {
        // Calculate rotation speed in degrees/second
        float rotationSpeed = 360f / (body.rotationPeriod * 3600f);

        // Reverse rotation for retrograde bodies
        if (body.retrograde)
        {
            rotationSpeed = -rotationSpeed;
        }

        // Apply tilt and rotation
        Quaternion tilt = Quaternion.Euler(body.tiltAngle, 0f, 0f);
        body.transform.rotation = tilt * Quaternion.Euler(0f, rotationSpeed * timeScale * Time.deltaTime, 0f);
    }
}
