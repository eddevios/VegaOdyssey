using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyType; // Tipo de enemigo en esta oleada.
    public int enemyCount; // Número de enemigos en la oleada.
    public float spawnInterval; // Intervalo entre cada enemigo.
    public float delayBeforeWave; // Retraso antes de iniciar esta oleada.
    public Vector3 spawnPosition; // Posición inicial de los enemigos.
    public float speed; // Velocidad de los enemigos.
    public float waveAmplitude; // Amplitud del movimiento ondulatorio (si aplica).
    public float waveFrequency; // Frecuencia del movimiento ondulatorio (si aplica).
    public int shotCount; // Cantidad de disparos por enemigo.
    public float shotPower; // Potencia de cada disparo.
}