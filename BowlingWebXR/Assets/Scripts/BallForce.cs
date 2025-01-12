using UnityEngine;

public class BallForce : MonoBehaviour
{
    public float forwardForce = 5000f; // Adjust this for how fast the ball should roll
    public PlayerMovement playerMovement;
    public BallMove ballMove;
    public GameObject trap;

    public bool hasLanded = false; // To ensure the force is applied only once

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball collides with the lane
        if (collision.gameObject.CompareTag("Lane") && !hasLanded && !Input.GetMouseButton(0))
        {
            hasLanded = true; // Ensure the force is applied only once
            playerMovement.enabled = false;
            ballMove.enabled = true;
            trap.SetActive(true);

            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply a forward force along the lane's forward direction
                Vector3 forwardDirection = collision.transform.forward;
                rb.AddForce(forwardDirection * forwardForce);
            }
        }

        // Check if the ball reaches the end platform
        if (collision.gameObject.CompareTag("End"))
        {
            // Disable ball movement and re-enable player movement
            playerMovement.enabled = true;
            ballMove.enabled = false;
            trap.SetActive(false);
        }
    }
}