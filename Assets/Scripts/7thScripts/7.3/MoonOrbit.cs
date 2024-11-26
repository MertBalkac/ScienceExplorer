using UnityEngine;

public class MooonOrbit : MonoBehaviour
{
    public Transform centralSphere; // The sphere to orbit around
    public float orbitSpeed = 50f;  // Speed of rotation
    public float orbitRadius = 5f;  // Radius of the orbit

    private float angle = 0f;

    void Update()
    {
        if (centralSphere != null)
        {
            // Increment the angle based on time and speed
            angle += orbitSpeed * Time.deltaTime;

            // Convert the angle to radians for the math functions
            float radians = angle * Mathf.Deg2Rad;

            // Calculate the new position
            float x = centralSphere.position.x + Mathf.Cos(radians) * orbitRadius;
            float z = centralSphere.position.z + Mathf.Sin(radians) * orbitRadius;

            // Update the position of the orbiting sphere
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
