using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    [Header("PROPIEDADES DEL POWER_UP")]
    [Tooltip("Amplitud de la Ola")][SerializeField] private float waveAmplitude;
    [Tooltip("Frecuencia de la Ola")][SerializeField] private float waveFrequency;
    [Tooltip("Velocidad de la Ola")][SerializeField] private float speed;
    [Tooltip("Cantidad de disparos enemigo de la Ola")][SerializeField] private int shotCount;
    [Tooltip("Cantidad de disparos enemigo de la Ola")][SerializeField] private float shotPower;
    [Tooltip("Prefab del proyectil")][SerializeField] public GameObject bulletPrefab;
    [Tooltip("Punto de salida del proyectil")][SerializeField] public Transform bulletSpawnPoint;
    [Tooltip("Tiempo en que el enemigo puede disparar de nuevo.")][SerializeField] private float nextShotTime = 0f;
    [Tooltip("Cantidad de disparos que se pueden realizar en un período de tiempo determinado.")]
    [SerializeField] private float fireRate = 1f;
    [Tooltip("Vida máxima del enemigo.")][SerializeField] private int maxHealth = 10;
    [Tooltip("Vida actual")][SerializeField] private int currentHealth;
    [Tooltip("Prefab de la explosión")][SerializeField] private GameObject explosionPrefab;
    private Camera mainCamera;
    private bool hasShot = false;

    private void Awake()
    {
        currentHealth = maxHealth; // Iniciar con la vida máxima.
    } 

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Instanciar la explosión en la posición del enemigo.
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // Despawning el enemigo.
        Lean.Pool.LeanPool.Despawn(gameObject);
    }

    public void Initialize(Transform player, float waveAmplitude, float waveFrequency, float speed, int shotCount, float shotPower)
    {
        this.player = player;
        this.waveAmplitude = waveAmplitude;
        this.waveFrequency = waveFrequency;
        this.speed = speed;
        this.shotCount = shotCount;
        this.shotPower = shotPower;

        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Movimiento ondulatorio.
        float y = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        // Disparo al entrar en pantalla.
        if (IsInView() && Time.time >= nextShotTime)
        {
            ShootAtPlayer();
            nextShotTime = Time.time + fireRate; // Actualiza el tiempo del próximo disparo.
        }

        // Desaparición al salir de la pantalla.
        if (IsOutOfView())
        {
            Lean.Pool.LeanPool.Despawn(gameObject);
        }
    }

    private void ShootAtPlayer()
    {
        if (player == null || bulletPrefab == null) return;

        for (int i = 0; i < shotCount; i++)
        {
            Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;
            GameObject bullet = Lean.Pool.LeanPool.Spawn(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * 10f; // Velocidad base de la bala.
            }

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetPower(shotPower); // Configura la potencia del disparo.
            }
        }
    }

    private bool IsInView()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        return screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1;
    }

    private bool IsOutOfView()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        return screenPos.x < -0.1f;
    }
}
