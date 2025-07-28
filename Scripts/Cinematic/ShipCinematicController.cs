using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCinematicController : MonoBehaviour
{
    [Header("PROPIEDADES DEL LA CINEM�TICA")]
    [Tooltip("Punto inicial de la nave")]
    [SerializeField] public Transform startPoint;
    [Tooltip("Punto central donde se detendr�")]
    [SerializeField] public Transform midPoint;
    [Tooltip("Punto final donde desaparecer�")]
    [SerializeField] public Transform endPoint;
    [Tooltip("Velocidad inicial de la nave")]
    [SerializeField] public float slowSpeed = 2f;
    [Tooltip("Velocidad final de la nave")]
    [SerializeField] public float fastSpeed = 10f;
    [Tooltip("Duraci�n de la pausa en el centro")]
    [SerializeField] public float pauseDuration = 2f;
    [Tooltip("�ngulo m�ximo de rotaci�n")]
    [SerializeField] public float rotationAngle = 5f;
    [Tooltip("Velocidad de la rotaci�n inicial y final")]
    [SerializeField] public float rotationSpeed = 2f;
    [Tooltip("Amplitud de la vibraci�n (para la pausa)")]
    [SerializeField] public float vibrationAmplitude = 0.1f;
    [Tooltip("Frecuencia de la vibraci�n (para la pausa)")]
    [SerializeField] public float vibrationFrequency = 25f;

    private int currentPhase = 0; // Controla en qu� fase est�
    private float pauseTimer = 0f; // Temporizador para la pausa
    private Vector3 originalPosition; // Posici�n base de la nave en cada frame
    private Quaternion originalRotation; // Rotaci�n base de la nave

    void Start()
    {
        // Inicializar la posici�n y rotaci�n de la nave
        transform.position = startPoint.position;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        switch (currentPhase)
        {
            case 0: // Fase inicial: Baja lentamente con rotaci�n
                originalPosition = Vector3.MoveTowards(transform.position, midPoint.position, slowSpeed * Time.deltaTime);
                ApplyRotation(); // Rotaci�n suave durante la ca�da
                if (Vector3.Distance(transform.position, midPoint.position) < 0.1f)
                {
                    currentPhase = 1; // Pasar a la fase de pausa
                    pauseTimer = pauseDuration;
                }
                break;

            case 1: // Fase intermedia: Pausa en el centro con vibraci�n
                pauseTimer -= Time.deltaTime;
                ApplyVibration(); // Vibraci�n mientras est� detenido
                if (pauseTimer <= 0)
                {
                    currentPhase = 2; // Pasar a la fase final
                    originalPosition = transform.position; // Asegurar la posici�n actual
                }
                break;

            case 2: // Fase final: Cae r�pidamente con rotaci�n
                originalPosition = Vector3.MoveTowards(transform.position, endPoint.position, fastSpeed * Time.deltaTime);
                ApplyRotation(); // Rotaci�n suave durante la ca�da final
                if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
                {
                    Destroy(gameObject); // Destruir la nave tras desaparecer
                }
                break;
        }

        // Actualizar posici�n base de la nave
        if (currentPhase != 1) // No sobrescribir durante la vibraci�n
        {
            transform.position = originalPosition;
        }
    }

    void ApplyRotation()
    {
        // Rotaci�n oscilante alrededor del eje Z
        float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;
        transform.rotation = originalRotation * Quaternion.Euler(0, 0, rotationZ);
    }

    void ApplyVibration()
    {
        // Crear una peque�a oscilaci�n alrededor de la posici�n base
        float offsetX = Mathf.Sin(Time.time * vibrationFrequency) * vibrationAmplitude;
        float offsetY = Mathf.Cos(Time.time * vibrationFrequency) * vibrationAmplitude;

        // Actualizar la posici�n de la nave con la vibraci�n
        transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);

        // Mantener la rotaci�n fija durante la pausa
        transform.rotation = originalRotation;
    }
}



