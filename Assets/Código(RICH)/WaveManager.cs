using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour
{  
    public int currentWave; // Número de la oleada actual
    public GameObject[] enemyPrefabs; // Prefabs de los enemigos (si deseas variar entre oleadas)
    public float waveStartDelay = 2f; // Tiempo de espera entre oleadas
    private bool isWaveActive = false; // Controla si una oleada está activa

    // Este método se llama para iniciar la siguiente oleada
    public void StartNextWave()
    {
        if (isWaveActive) return; // Si ya hay una oleada activa, no hace nada

        isWaveActive = true; // Activa la oleada

        // Muestra un mensaje de la oleada actual
        Debug.Log("Iniciando oleada " + currentWave);

        // Genera enemigos para la oleada actual (dependiendo de la oleada)
        SpawnEnemiesForWave(currentWave);

        // Espera el tiempo especificado antes de iniciar la próxima oleada
        StartCoroutine(WaitAndStartNextWave(waveStartDelay));
    }

    // Genera los enemigos para la oleada actual (esto puede cambiar según cómo quieras hacerlo)
    void SpawnEnemiesForWave(int wave)
    {
        int numberOfEnemies = wave * 5; // Ejemplo: la oleada 1 tiene 5 enemigos, la 2 tiene 10, etc.

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Aquí va el código para generar enemigos, puedes modificarlo según tu lógica
            Debug.Log("Generando enemigo para la oleada " + wave);
        }
    }

    // Método para esperar un tiempo antes de iniciar la siguiente oleada
    IEnumerator WaitAndStartNextWave(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Ahora que la oleada ha terminado, aumentamos la oleada
        currentWave++;
        isWaveActive = false; // Desactiva la oleada actual
    }
}
