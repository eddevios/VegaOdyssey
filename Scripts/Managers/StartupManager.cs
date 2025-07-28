using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartupManager : MonoBehaviour
{
    [Header("ESCENA")]
    [Tooltip("Cargar siguiente escena")][SerializeField] public string sceneToLoad;
    [Tooltip("Referencia al GameManager")][SerializeField] private GameManager _gameManager;
    [Header("AUDIO")]
    [Tooltip("Audio Souce de la escena")][SerializeField] public AudioSource sceneAudioSource;
    [Tooltip("Referencia Audio Manager")][SerializeField] public AudioManager audioManager;
    [Tooltip("Audio Clip de la escena")][SerializeField] public AudioClip clip;

    private void Awake()
    {
        sceneAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Debug.Log("CARGA LENGUAJE");
        // Obtener el idioma guardado en PlayerPrefs
        string savedLanguage = LanguageManager.LoadLanguage();
        Debug.Log("LENGUAJE GUARDADO: " + LocalizationSettings.SelectedLocale);
        if (!string.IsNullOrEmpty(savedLanguage))
        {
            // Configurar el idioma guardado
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(savedLanguage);
        }
        else
        {
            // Si no hay idioma guardado, usar el idioma por defecto
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
        Debug.Log("LENGUAJE: " + LocalizationSettings.SelectedLocale);
    }

    public void LoadScene()
    {
        _gameManager.LoadNextScene(sceneToLoad);
    }

    void LoadSound()
    {
        sceneAudioSource.loop = false;
        sceneAudioSource.clip = clip;
        sceneAudioSource.Play();
    }
}