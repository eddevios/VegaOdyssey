using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("GAME MANAGER")]
    [Tooltip("Instancia compartida de GameManager")][SerializeField] private GameManager _gameManager;
    [Header("AUDIO")]
    [Tooltip("Audio Souce de la escena")][SerializeField] private AudioSource _sceneAudioSource;
    [Tooltip("Audio Manager")][SerializeField] private AudioManager _audioManager;
    [Tooltip("Clip de Audio")][SerializeField] public AudioClip clip;

    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void Start()
    {
        LoadSound();
        //RESET PLAYERPREFS, Commentar normalmente
        //UserPreferences.ResetTerms();
    }

    void LoadSound()
    {
        _audioManager.PlayMusic(clip.name, true, 1.0f);
    }

    public void LoadScene()
    {
        _gameManager.InitializeGameFlow();

    }
}