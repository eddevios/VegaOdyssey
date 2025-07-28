using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [Header("MANAGERS")]
    [Tooltip("Referencia al GameManager")]
    [SerializeField] private GameManager _gameManager;

    [Header("UI")]
    [Tooltip("Slider de progreso")]
    [SerializeField] private Slider progressBar;
    [Tooltip("Texto del porcentaje de carga")]
    [SerializeField] private TextMeshProUGUI progressText;

    [Header("Configuración")]
    [Tooltip("Tiempo mínimo para mostrar la pantalla de carga")]
    [SerializeField] private float minimumLoadingTime = 2.0f;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager no encontrado. Asegúrate de que exista en la escena.");
        }
    }

    private void Start()
    {
        if (_gameManager != null)
        {
            string targetScene = _gameManager.GetTargetScene();
            StartCoroutine(LoadSceneAsync(targetScene));
        }
        else
        {
            Debug.LogError("No se puede cargar la escena porque no se obtuvo el GameManager.");
        }
    }
    
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        float elapsedTime = 0f;

        // Comienza la carga de la escena en segundo plano
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; // Pausa la activación automática
        while (!operation.isDone)
        {
            elapsedTime += Time.deltaTime;

            // Actualiza el progreso del slider
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = Mathf.Min(progress, elapsedTime / minimumLoadingTime);

            // Actualiza el texto del progreso
            int progressPercentage = Mathf.RoundToInt(progressBar.value * 100);
            progressText.text = progressPercentage + " %";

            // Activa la escena cuando ambas condiciones se cumplan
            if (operation.progress >= 0.9f && elapsedTime >= minimumLoadingTime)
            {
                operation.allowSceneActivation = true;
            }
            //Debug.Log("SLIDER VALUE: " + progressBar.value);
            yield return null;
        }
        Debug.Log("Escena cargada: " + sceneName);
    }
}