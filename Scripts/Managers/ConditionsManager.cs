using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConditionsManager : MonoBehaviour
{
    [Header("GAME MANAGER")]
    [Tooltip("Instancia compartida de GameManager")][SerializeField] private GameManager _gameManager;
    [Header("AUDIO")]
    [Tooltip("Audio Souce de la escena")][SerializeField] private AudioSource _sceneAudioSource;
    [Tooltip("Audio Manager")][SerializeField] private AudioManager _audioManager;
   
    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void OnUnacceptTermsButtonPressed()
    {
        _gameManager.LoadNextScene("01_StartScreen");
    }

    public void OnAcceptTermsButtonPressed()
    {
        UserPreferences.AcceptTerms();
        _gameManager.LoadNextScene("03_MainMenu");
    }
}