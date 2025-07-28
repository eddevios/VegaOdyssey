using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCinematicController : MonoBehaviour
{
    [Header("PROPIEDADES DEL LA CINEMÁTICA")]
    [Tooltip("Punto inicial de la nave")]
    [SerializeField] public Transform startPoint;
    [Tooltip("Punto central donde se detendrá")]
    [SerializeField] public Transform midPoint;
    [Tooltip("Punto final donde desaparecerá")]
    [SerializeField] public Transform endPoint;
    [Tooltip("Velocidad inicial de la nave")]
    [SerializeField] public float slowSpeed = 2f;
    [Tooltip("Velocidad final de la nave")]
    [SerializeField] public float fastSpeed = 10f;
    [Tooltip("Duración de la pausa en el centro")]
    [SerializeField] public float pauseDuration = 2f;
    [Tooltip("Ángulo máximo de rotación")]
    [SerializeField] public float rotationAngle = 5f;
    [Tooltip("Velocidad de la rotación inicial y final")]
    [SerializeField] public float rotationSpeed = 2f;
    [Tooltip("Amplitud de la vibración (para la pausa)")]
    [SerializeField] public float vibrationAmplitude = 0.1f;
    [Tooltip("Frecuencia de la vibración (para la pausa)")]
    [SerializeField] public float vibrationFrequency = 25f;

    private int currentPhase = 0; // Controla en qué fase está
    private float pauseTimer = 0f; // Temporizador para la pausa
    private Vector3 originalPosition; // Posición base de la nave en cada frame
    private Quaternion originalRotation; // Rotación base de la nave

    void Start()
    {
        // Inicializar la posición y rotación de la nave
        transform.position = startPoint.position;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        switch (currentPhase)
        {
            case 0: // Fase inicial: Baja lentamente con rotación
                originalPosition = Vector3.MoveTowards(transform.position, midPoint.position, slowSpeed * Time.deltaTime);
                ApplyRotation(); // Rotación suave durante la caída
                if (Vector3.Distance(transform.position, midPoint.position) < 0.1f)
                {
                    currentPhase = 1; // Pasar a la fase de pausa
                    pauseTimer = pauseDuration;
                }
                break;

            case 1: // Fase intermedia: Pausa en el centro con vibración
                pauseTimer -= Time.deltaTime;
                ApplyVibration(); // Vibración mientras está detenido
                if (pauseTimer <= 0)
                {
                    currentPhase = 2; // Pasar a la fase final
                    originalPosition = transform.position; // Asegurar la posición actual
                }
                break;

            case 2: // Fase final: Cae rápidamente con rotación
                originalPosition = Vector3.MoveTowards(transform.position, endPoint.position, fastSpeed * Time.deltaTime);
                ApplyRotation(); // Rotación suave durante la caída final
                if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
                {
                    Destroy(gameObject); // Destruir la nave tras desaparecer
                }
                break;
        }

        // Actualizar posición base de la nave
        if (currentPhase != 1) // No sobrescribir durante la vibración
        {
            transform.position = originalPosition;
        }
    }

    void ApplyRotation()
    {
        // Rotación oscilante alrededor del eje Z
        float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;
        transform.rotation = originalRotation * Quaternion.Euler(0, 0, rotationZ);
    }

    void ApplyVibration()
    {
        // Crear una pequeña oscilación alrededor de la posición base
        float offsetX = Mathf.Sin(Time.time * vibrationFrequency) * vibrationAmplitude;
        float offsetY = Mathf.Cos(Time.time * vibrationFrequency) * vibrationAmplitude;

        // Actualizar la posición de la nave con la vibración
        transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);

        // Mantener la rotación fija durante la pausa
        transform.rotation = originalRotation;
    }
}



