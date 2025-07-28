using UnityEngine;
using Lean.Pool;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;
    private float power = 1f;

    private void OnEnable()
    {
        // Destruir la bala autom�ticamente despu�s de un tiempo si no interact�a.
        Invoke(nameof(Despawn), lifeTime);
    }

    private void OnDisable()
    {
        // Cancelar el despawn autom�tico al desactivar la bala.
        CancelInvoke(nameof(Despawn));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(Mathf.RoundToInt(power)); // Aplicar el da�o seg�n la potencia.
            }

            Lean.Pool.LeanPool.Despawn(gameObject);
            Despawn();
        }
        else if (collision.CompareTag("Environment"))
        {
            // Opcional: manejar colisiones con el entorno.
            Despawn();
        }
    }

    public void SetPower(float newPower)
    {
        power = newPower;
    }

    private void Despawn()
    {
        // Despawning la bala usando Lean Pool.
        LeanPool.Despawn(gameObject);
    }

    private void OnBecameInvisible()
    {
        // Si la bala sale de la pantalla, se destruye.
        Despawn();
    }
}