using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage = 10; // Daño infligido por la bala.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Aplica daño al jugador.
            }

            // Destruir la bala después de impactar.
            Lean.Pool.LeanPool.Despawn(gameObject);
        }
    }
}
