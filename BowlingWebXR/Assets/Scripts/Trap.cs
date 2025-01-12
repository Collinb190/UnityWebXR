using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject ballRespawn;
    public BallForce ballForce;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball hits trap
        if (collision.gameObject.CompareTag("Trap"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            gameObject.transform.position = ballRespawn.transform.position;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            ballForce.hasLanded = false;
        }
    }
}
