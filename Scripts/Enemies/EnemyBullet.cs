using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage = 10; // Da�o infligido por la bala.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Aplica da�o al jugador.
            }

            // Destruir la bala despu�s de impactar.
            Lean.Pool.LeanPool.Despawn(gameObject);
        }
    }
}
