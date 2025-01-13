using System.Collections;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isFallen = false;

    void Update()
    {
        // Check if the pin's x or z rotation exceeds the threshold
        if (!isFallen && (transform.eulerAngles.x > 10 && transform.eulerAngles.x < 350 ||
                          transform.eulerAngles.z > 10 && transform.eulerAngles.z < 350))
        {
            isFallen = true;
            Debug.Log($"Pin {gameObject.name} has fallen!");
            StartCoroutine(DeactivatePinAfterDelay(3f));
            // Add additional logic for scoring here
        }
    }

    private IEnumerator DeactivatePinAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        gameObject.SetActive(false); // Deactivate the pin
    }
}
