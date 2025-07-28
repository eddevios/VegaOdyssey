using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [Tooltip("Referencia a Boton")][SerializeField] private Button _button;
    [Tooltip("Clip de Audio")][SerializeField] public AudioClip clickSound;
    [Header("AUDIO")]
    [Tooltip("Audio Manager")][SerializeField] private AudioManager _audioManager;
    private void Awake()
    {
        _button = GetComponent<Button>();
        // Si no se ha asignado el AudioManager en el inspector, intentamos encontrarlo en la escena
        if (_audioManager == null)
        {
            _audioManager = FindFirstObjectByType<AudioManager>();
            if (_audioManager == null)
            {
                Debug.LogWarning("AudioManager no encontrado en la escena.");
            }
        }
    }
    void Start()
    {
        _button.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        if (_audioManager != null && clickSound != null)
        {
            _audioManager.PlaySoundEffect(clickSound.name, false, 1f);
        }
    }
}