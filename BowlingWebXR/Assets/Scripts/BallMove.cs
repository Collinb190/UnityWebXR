using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Only allow movement along the X-axis (left and right)
        Vector3 direction = new Vector3(horizontal, 0, 0);

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
