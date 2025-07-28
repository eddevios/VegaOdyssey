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
    [Tooltip("Audio Clip del men�")]
    [SerializeField] private AudioClip clip;

    [Header("VARIABLES")]
    [Tooltip("Botones")]
    [SerializeField] private string playScene;
    [SerializeField] private string optionsScene;

    private void Awake()
    {
        // Busca los managers si no est�n asignados manualmente
        if (_gameManager == null)
            _gameManager = FindObjectOfType<GameManager>();
        if (_audioManager == null)
            _audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        // Opcional: Reproducir m�sica del men� si est� asignada
        if (sceneAudioSource != null && clip != null)
        {
            sceneAudioSource.clip = clip;
            sceneAudioSource.Play();
        }
    }

    // M�todos para los botones
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

