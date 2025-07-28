using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject speedPowerUpPrefab;
    [SerializeField] private GameObject bombPowerUpPrefab;
    [SerializeField] private GameObject shieldPowerUpPrefab;

    private void Start()
    {
        // Invoca la generación de un power-up aleatorio cada 10 segundos
        InvokeRepeating("SpawnRandomPowerUp", 0f, 10f);
    }

    private void SpawnRandomPowerUp()
    {
        // Elige un tipo de power-up aleatorio
        int randomType = Random.Range(0, 3); // 0: Speed, 1: Bomb, 2: Shield

        // Genera el power-up correspondiente al tipo aleatorio
        switch (randomType)
        {
            case 0:
                SpawnPowerUp(speedPowerUpPrefab);
                break;
            case 1:
                SpawnPowerUp(bombPowerUpPrefab);
                break;
            case 2:
                SpawnPowerUp(shieldPowerUpPrefab);
                break;
            default:
                Debug.LogError("Tipo de power-up aleatorio no reconocido");
                break;
        }
    }

    private void SpawnPowerUp(GameObject powerUpPrefab)
    {
        if (powerUpPrefab != null)
        {
            GameObject powerUp = Instantiate(powerUpPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            // Accede al script PowerUp del nuevo objeto y asigna su tipo
            PowerUp powerUpScript = powerUp.GetComponent<PowerUp>();
            if (powerUpScript != null)
            {
                powerUpScript.powerUpType = powerUpPrefab.GetComponent<PowerUp>().powerUpType;
                powerUpScript.SetRandomPosition(); // Llama al método SetRandomPosition
            }
            else
            {
                Debug.LogError("El objeto PowerUp no tiene el componente PowerUp adjunto.");
            }
        }
        else
        {
            Debug.LogError("Prefab de power-up no asignado");
        }
    }
}
