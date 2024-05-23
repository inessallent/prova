using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corridor : MonoBehaviour
{
    // Singleton instance
    public static corridor Instance { get; private set; }

    public AudioClip corridorClip;
    private AudioSource audioSource;

    private void Awake()
    {
        // Implementing the singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        // Call PlayCorridorIntro after 5 seconds
        Invoke("PlayCorridorIntro", 3f);
    }

    public void PlayCorridorIntro()
    {
        if (corridorClip != null && audioSource != null)
        {
            audioSource.clip = corridorClip;
            audioSource.Play();
        }
    }
}
