using UnityEngine;

public class BallController : MonoBehaviour
{
    public float forwardForce = 10000f; // Adjust this for how fast the ball should roll
    private bool hasLanded = false; // To ensure the force is applied only once

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball collides with the lane
        if (collision.gameObject.CompareTag("Lane") && !hasLanded)
        {
            hasLanded = true; // Ensure the force is applied only once
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply a forward force along the lane's forward direction
                Vector3 forwardDirection = collision.transform.forward;
                rb.AddForce(forwardDirection * forwardForce);
            }
        }
    }
}