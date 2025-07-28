using System.Collections;
using UnityEngine;
using Lean.Pool; // Importar Lean Pool

public class EnemyGroupController : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos para diferentes oleadas.
    public Wave[] waves; // Lista de oleadas configurables.

    private Transform player; // Referencia al jugador.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        foreach (Wave wave in waves)
        {
            yield return new WaitForSeconds(wave.delayBeforeWave);
            for (int i = 0; i < wave.enemyCount; i++)
            {
                SpawnEnemy(wave.enemyType, wave.spawnPosition, wave.speed, wave.waveAmplitude, wave.waveFrequency, wave.shotCount, wave.shotPower);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab, Vector3 spawnPosition, float speed, float waveAmplitude, float waveFrequency, int shotCount, float shotPower)
    {
        GameObject enemy = LeanPool.Spawn(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.Initialize(player, waveAmplitude, waveFrequency, speed, shotCount, shotPower);
    }
}