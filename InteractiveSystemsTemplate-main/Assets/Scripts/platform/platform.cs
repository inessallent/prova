using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float shakeDuration = 1.0f;  // Duration of the shake
    public float shakeMagnitude = 0.1f; // Magnitude of the shake
    public float blinkFrequency = 0.1f; // Frequency of the blink effect

    private Vector3 originalPosition;
    private Renderer platformRenderer;
    private Color originalColor;
    private List<GameObject> playersOnPlatform = new List<GameObject>(); // List of players on this platform

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition; // Store the original position of the platform
        platformRenderer = GetComponent<Renderer>(); // Get the Renderer component
        if (platformRenderer != null)
        {
            originalColor = platformRenderer.material.color; // Store the original color of the platform
        }
    }

    void Update()
    {
        
    }

    public void TriggerShakeAndBlink()
    {
        StartCoroutine(ShakeAndBlink());
    }

    private IEnumerator ShakeAndBlink()
    {
        float elapsed = 0.0f;
        bool isRed = false;

        while (elapsed < shakeDuration)
        {
            // Shake logic
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            // Blink logic
            if (platformRenderer != null)
            {
                platformRenderer.material.color = isRed ? originalColor : Color.red;
                isRed = !isRed;
            }

            elapsed += blinkFrequency;
            yield return new WaitForSeconds(blinkFrequency);
        }

        // Restore the original state
        transform.localPosition = originalPosition;
        if (platformRenderer != null)
        {
            platformRenderer.material.color = originalColor;
        }

        // Remove players from the platform
        foreach (var player in playersOnPlatform)
        {
            if (player != null)
            {
                Destroy(player);
            }
        }
        playersOnPlatform.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersOnPlatform.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersOnPlatform.Remove(other.gameObject);
        }
    }
}






