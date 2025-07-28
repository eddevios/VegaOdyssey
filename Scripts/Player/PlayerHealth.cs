using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de Salud")]
    [Tooltip("Salud máxima del jugador")]
    [SerializeField] private int maxHealth = 100;
    [Tooltip("Barra de salud (Slider UI)")]
    [SerializeField] public Slider healthSlider;

    private int currentHealth;
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager no encontrado en el jugador.");
        }

        // Inicializar la salud.
        currentHealth = maxHealth;

        // Configurar el slider.
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.LogError("Slider de salud no asignado.");
        }
    }

    public void TakeDamage(int damage)
    {
        if (playerManager.IsDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Actualizar la barra de salud.
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        playerManager.SetDead();
        Debug.Log("El jugador ha muerto.");

        // Aquí puedes añadir efectos visuales, sonidos, etc.
        // Ejemplo: Cambiar a otra escena.
        // SceneManager.LoadScene("GameOver");
    }

    public void Heal(int amount)
    {
        if (playerManager.IsDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Actualizar la barra de salud.
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
}
