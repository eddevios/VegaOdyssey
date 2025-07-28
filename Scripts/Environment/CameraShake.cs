using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPosition;
    [Tooltip("La duración del efecto de sacudida")]
    [SerializeField] private float _shakeDuration = 0f;
    [Tooltip("La intensidad de la sacudida (cuánto se moverá la cámara)")]
    [SerializeField] private float _shakeIntensity = 0f;
    [Tooltip("Controla la rapidez con que la sacudida disminuye con el tiempo")]
    [SerializeField] private float _shakeDecay = 0.1f;

    private void Start()
    {
        _originalPosition = Camera.main.transform.localPosition;
    }

    private void Update()
    {
        if (_shakeDuration > 0)
        {
            Camera.main.transform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeIntensity;

            _shakeDuration -= Time.deltaTime;
            _shakeIntensity = Mathf.Lerp(_shakeIntensity, 0, _shakeDecay);

            if (_shakeDuration <= 0)
            {
                Camera.main.transform.localPosition = _originalPosition;
            }
        }
    }

    // Función para activar la sacudida de cámara
    public void Shake(float duration, float intensity)
    {
        Debug.Log("SHAKEEEE");
        _shakeDuration = duration;
        _shakeIntensity = intensity;
    }
}