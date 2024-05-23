using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mommy : MonoBehaviour
{
    public AudioClip revealClip1; // Primer audio
    public AudioClip appearClip2; // Segundo audio
    private AudioSource audioSource;
    public GameObject mommyModel; // GameObject que contiene el modelo de Blender
    private bool isMoving = false;

    // Velocidad del movimiento de la momia
    public float moveSpeed = 5f;

    private void Awake()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Verificar si mommyModel está asignado
        if (mommyModel == null)
        {
            Debug.LogError("mommyModel GameObject is not assigned.");
        }
    }

    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        if (mommyModel != null)
        {
            // Inicialmente esconder la momia
            mommyModel.SetActive(false);

            // Iniciar la corrutina para manejar la secuencia de eventos
            StartCoroutine(RevealSequence());
        }
    }

    private IEnumerator RevealSequence()
    {
        // Reproducir el primer audio
        if (revealClip1 != null && audioSource != null)
        {
            audioSource.clip = revealClip1;
            audioSource.Play();

            // Esperar a que el primer audio termine de reproducirse
            yield return new WaitForSeconds(revealClip1.length);
        }

        // Hacer visible la momia
        if (mommyModel != null)
        {
            mommyModel.SetActive(true);
        }

        // Reproducir el segundo audio
        if (appearClip2 != null && audioSource != null)
        {
            audioSource.clip = appearClip2;
            audioSource.Play();

            // Esperar a que el segundo audio termine de reproducirse
            yield return new WaitForSeconds(appearClip2.length);
        }

        // Iniciar el movimiento de la momia
        isMoving = true;
    }

    // Update se llama una vez por frame
    void Update()
    {
        if (isMoving)
        {
            // Mover la momia hacia adelante
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
