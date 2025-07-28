using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class AudioOptions : MonoBehaviour
{
    [Header("AUDIO")]
    [Tooltip("Audio Manager")][SerializeField] private AudioManager _audioManager;
    [Tooltip("OST Escena de opcionesS")][SerializeField] public AudioClip BackgroundOST;
    //SOUNDS
    [Tooltip("Slider de Volumen")][SerializeField] public Slider slider;
    [Tooltip("Valor del Slider")][SerializeField] public float sliderValue;
    [Tooltip("Imagen para icon de mute")][SerializeField] public Image imageMute;
    //SFX
    [Tooltip("Slider de VolumenSFX")][SerializeField] public Slider sliderSFX;
    [Tooltip("Valor del SliderSFX")][SerializeField] public float sliderValueSFX;
    [Tooltip("Imagen para icon de mute")][SerializeField] public Image SFXimageMute;


    void Awake()
    {
        //AUDIO MANAGER
        _audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void Start()
    {
        //BG MUSIC
        float OSTVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        _audioManager.SetMusicVolume(OSTVolume);

        //AUDIO TOOLS
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        AudioListener.volume = slider.value;
        sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        AudioListener.volume = sliderSFX.value;
        isMute();
    }

    //AUDIO
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        AudioListener.volume = slider.value;
        isMute();
    }

    public void ChangeSFXSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
        AudioListener.volume = slider.value;
        isMute();
    }

    public void isMute()
    {
        if (sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
        if (sliderValueSFX == 0)
        {
            SFXimageMute.enabled = true;
        }
        else
        {
            SFXimageMute.enabled = true;
        }
    }
    void OnDestroy()
    {
        Debug.Log("AudioManager OnDestroy");
    }
}
