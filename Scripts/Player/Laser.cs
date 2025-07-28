using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Laser : MonoBehaviour
{
    [Header("Propiedades del disparo")]
    [Tooltip("Velocidad de movimiento del disparo")]
    [SerializeField] private float _speed = 10.0f;
    [Tooltip("Fuerza del disparo que determina el daño que inflige")]
    [SerializeField] private int _force = 5; // Fuerza del disparo.

    public int Force => _force; // Getter para acceder a la fuerza del disparo.

    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.x >= 10f)
        {
            Destroy(gameObject); // Puede sustituirse por Lean.Pool.Despawn si es necesario.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_force); // Usa la fuerza del disparo para infligir daño.
            }

            Destroy(gameObject); // Puede sustituirse por Lean.Pool.Despawn.
        }
    }
}
