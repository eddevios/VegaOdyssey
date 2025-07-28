using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class MainMenuManager : MonoBehaviour
{
    [Header("MANAGERS")]
    [Tooltip("Referencia al GameManager")]
    [SerializeField] private GameManager _gameManager;
    [Header("AUDIO")]
    [Tooltip("Audio Source de la escena")]
    [SerializeField] private AudioSource sceneAudioSource;
    [Tooltip("Referencia al Audio Manager")]
    [SerializeField] private AudioManager _audioManager;
    [Tooltip("Audio Clip del menú")]
    [SerializeField] private AudioClip clip;

    [Header("VARIABLES")]
    [Tooltip("Botones")]
    [SerializeField] private string playScene;
    [SerializeField] private string optionsScene;

    private void Awake()
    {
        // Busca los managers si no están asignados manualmente
        if (_gameManager == null)
            _gameManager = FindObjectOfType<GameManager>();
        if (_audioManager == null)
            _audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        // Opcional: Reproducir música del menú si está asignada
        if (sceneAudioSource != null && clip != null)
        {
            sceneAudioSource.clip = clip;
            sceneAudioSource.Play();
        }
    }

    // Métodos para los botones
    public void PlayGame()
    {
        _gameManager.LoadSceneWithLoading(playScene);
    }

    public void OpenOptions()
    {
        Debug.Log("ENTRA OPTIONS");
        _gameManager.LoadNextScene(optionsScene);
    }

    public void OpenCredits()
    {
        _gameManager.LoadCreditsScene();
    }

    public void ExitGame()
    {
        _gameManager.ExitGame();
    }
}

