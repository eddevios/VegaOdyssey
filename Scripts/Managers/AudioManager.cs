using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Referencia al Audio Manager")][SerializeField] public static AudioManager instance;
    [Tooltip("Referencia a efectos SFX")][SerializeField] public AudioClip[] soundEffects;
    [Tooltip("Referencia al OST")][SerializeField] public AudioClip[] backgroundMusic;
    [Tooltip("Referencia al Volumen de Musica en PlayerPrefs")][SerializeField] private const string MUSIC_VOLUME_KEY = "MusicVolume";
    [Tooltip("Referencia al Volumen de SFX en PlayerPrefs")][SerializeField] private const string SFX_VOLUME_KEY = "SFXVolume";
    [Tooltip("Referencia a OST")][SerializeField] private Dictionary<string, AudioSource> sfxSources = new Dictionary<string, AudioSource>();
    [Tooltip("Referencia a efectos SFX")][SerializeField] private Dictionary<string, AudioSource> bgMusicSources = new Dictionary<string, AudioSource>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Añadir AudioSource para cada efecto de sonido
        foreach (AudioClip soundEffect in soundEffects)
        {
            AudioSource sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.playOnAwake = false;
            sfxSources.Add(soundEffect.name, sfxSource);
        }

        // Añadir AudioSource para la música de fondo
        foreach (AudioClip bgMusicClip in backgroundMusic)
        {
            AudioSource bgMusicSource = gameObject.AddComponent<AudioSource>();
            bgMusicSource.playOnAwake = false;
            bgMusicSources.Add(bgMusicClip.name, bgMusicSource);
        }

        // Establecer el volumen inicial desde PlayerPrefs o utilizar valores predeterminados
        SetMusicVolume(PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1.0f));
        SetSFXVolume(PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1.0f));
    }

    public void PlayMusic(string title, bool loop, float volume)
    {
        if (bgMusicSources.TryGetValue(title, out AudioSource bgMusicSource))
        {
            bgMusicSource.clip = FindAudioClip(title, backgroundMusic);
            bgMusicSource.loop = loop;
            bgMusicSource.volume = volume;
            bgMusicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music not found: " + title);
        }
    }

    public void PlaySoundEffect(string title, bool loop, float volume)
    {
        if (sfxSources.TryGetValue(title, out AudioSource sfxSource))
        {
            sfxSource.clip = FindAudioClip(title, soundEffects);
            sfxSource.loop = loop;
            sfxSource.volume = volume;
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound effect not found: " + title);
        }
    }

    public void SetMusicVolume(float volume)
    {
        foreach (var bgMusicSources in bgMusicSources.Values)
        {
            bgMusicSources.volume = volume;
        }

        // Guardar el volumen en PlayerPrefs
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        foreach (var sfxSource in sfxSources.Values)
        {
            sfxSource.volume = volume;
        }

        // Guardar el volumen en PlayerPrefs
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    private AudioClip FindAudioClip(string title, AudioClip[] clipArray)
    {
        foreach (AudioClip clip in clipArray)
        {
            if (clip.name == title)
            {
                return clip;
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        StopAllSounds();
    }

    private void StopAllSounds()
    {
        // Implementa según tu necesidad
    }

    public void StopMusic()
    {
        //print("APAGA MUSICA");
        foreach (var bgMusicSource in bgMusicSources.Values)
        {
            if (bgMusicSource.isPlaying)
            {
                bgMusicSource.Stop();
            }
        }
    }

    public void StopSoundEffect(string title)
    {
        if (sfxSources.TryGetValue(title, out AudioSource sfxSource))
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }
        }
        else
        {
            Debug.LogWarning("Sound effect not found: " + title);
        }
    }

    public bool IsPlaying()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.isPlaying)
            {
                return true;
            }
        }
        return false;
    }
}


/*
 //EJEMPLO DE USO
void Update()
    {
        // Ejemplo: Detectar un puñetazo y reproducir el sonido
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Obtener el volumen almacenado en PlayerPrefs (puedes ajustar la clave según tus necesidades)
            float punchVolume = PlayerPrefs.GetFloat("PunchVolume", 1.0f);

            // Reproducir el sonido del puñetazo con loop desactivado y el volumen obtenido de PlayerPrefs
            audioManager.PlaySoundEffect("PunchSound", false, punchVolume);
        }
    }
 
 */