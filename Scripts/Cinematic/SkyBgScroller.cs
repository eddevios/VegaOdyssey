using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBgScroller : MonoBehaviour
{
    [Header("PROPIEDADES DEL FONDO Y SU SCROLL")]
    [Tooltip("Velocidad a la que se mueve el fondo")]
    [SerializeField] public float scrollSpeed = 2f;
    [Tooltip("Margen opcional para detener el fondo antes de la parte inferior de la pantalla")]
    [SerializeField] public float margin = 0.1f;
    [Tooltip("Desplazamiento adicional en p�xeles")]
    [SerializeField] public float pixelOffset = 100f;
    [Tooltip("L�mite superior de movimiento")]
    [SerializeField] private float stopPosition;

    [Header("PROPIEDADES DE TRANSICI�N")]
    [Tooltip("Objeto de explosi�n que se activar� antes de la transici�n")]
    [SerializeField] public GameObject explosionObject;
    [Tooltip("Objeto de nubes que se activa y desactiva")]
    [SerializeField] public GameObject cloudsObject;

    [Header("TEMPORIZADOR PARA NUBES")]
    [Tooltip("Tiempo en segundos despu�s del inicio para activar el objeto de nubes")]
    [SerializeField] private float cloudsActivationDelay = 2f;
    [Tooltip("Duraci�n en segundos que el objeto de nubes estar� activo")]
    [SerializeField] private float cloudsActiveDuration = 5f;

    private bool cloudsCoroutineStarted = false;

    void Start()
    {
        // Obtener la c�mara principal
        Camera mainCamera = Camera.main;

        // Verificar si el objeto tiene un SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("El objeto no tiene un componente SpriteRenderer.");
            enabled = false;
            return;
        }

        // Convertir pixelOffset a unidades del mundo
        float worldOffset = pixelOffset / Screen.height * (2 * mainCamera.orthographicSize);

        // Calcular la posici�n l�mite inferior donde el fondo debe detenerse
        float bgBottomEdge = transform.position.y - (spriteRenderer.bounds.size.y / 2);
        float cameraBottomEdge = mainCamera.transform.position.y - mainCamera.orthographicSize;

        // Ajustar stopPosition con margen y desplazamiento en p�xeles
        stopPosition = cameraBottomEdge + (spriteRenderer.bounds.size.y / 2) - margin + worldOffset;

        // Iniciar la rutina para manejar las nubes
        if (cloudsObject != null)
        {
            StartCoroutine(HandleCloudsActivation());
        }
        else
        {
            Debug.LogWarning("CloudsObject no est� asignado en el inspector.");
        }
    }

    void Update()
    {
        // Mover el fondo hacia arriba solo si no ha alcanzado la posici�n l�mite
        if (transform.position.y < stopPosition)
        {
            transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        }
        else
        {
            // Activar el objeto de explosi�n si est� asignado
            if (explosionObject != null)
            {
                explosionObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("ExplosionObject no est� asignado en el inspector.");
            }

            // Lanzar la transici�n
            FindObjectOfType<SceneTransitionManager>().FadeToScene("Phase1_PlanetSurface");
        }
    }

    /// <summary>
    /// Activa el objeto de nubes despu�s de un tiempo y lo desactiva tras una duraci�n.
    /// </summary>
    private IEnumerator HandleCloudsActivation()
    {
        // Esperar el tiempo de activaci�n
        yield return new WaitForSeconds(cloudsActivationDelay);

        // Activar el objeto de nubes
        cloudsObject.SetActive(true);

        // Esperar la duraci�n activa
        yield return new WaitForSeconds(cloudsActiveDuration);

        // Desactivar el objeto de nubes
        cloudsObject.SetActive(false);
    }
}
