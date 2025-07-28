using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Speed,
        Bomb,
        Shield
    }
    [Header("PROPIEDADES DEL POWER_UP")]
    [Tooltip("Tipo de PowerUp")][SerializeField] public PowerUpType powerUpType;

    [SerializeField] private float speed = 2f; // Velocidad
    [SerializeField] private float oscillationAmplitude = 1.5f; // Amplitud de la oscilaci�n vertical
    [SerializeField] private float oscillationFrequency = 2f; // Frecuencia de la oscilaci�n vertical
    [SerializeField] private float destroyXPosition = -10f; // Posici�n X que activa la destrucci�n si se supera

    private void Start()
    {
        SetRandomPosition();
    }

    void Update()
    {
        // Movimiento de derecha a izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Oscilaci�n vertical
        float yOffset = oscillationAmplitude * Mathf.Sin(oscillationFrequency * Time.time);
        transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

        // Verificar si se sale de la pantalla
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Notificar al jugador y destruir el power-up
            PlayerPowerUpHandler playerPowerUpHandler = other.GetComponent<PlayerPowerUpHandler>();
            if (playerPowerUpHandler != null)
            {
                print("POWERUP TYPE: " + powerUpType);
                playerPowerUpHandler.ApplyPowerUp(powerUpType);
            }
            print("DESTRUIR");
            Destroy(gameObject);
        }
    }

    public void SetRandomPosition()
    {
        transform.position = new Vector3(10f, Random.Range(-4f, 3.2f), transform.position.z);
    }
}
