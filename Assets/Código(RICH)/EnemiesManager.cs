using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesManager : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab del enemigo
    public Vector2 spawnArea;           // Área de spawn alrededor del jugador
    public GameObject player;           // Referencia al jugador

    public float waveDelay = 5f;        // Tiempo entre oleadas (si todos los enemigos están muertos)
    private float waveTimer;            // Temporizador para la siguiente oleada
    private int currentWave = 1;        // Número de la oleada actual
    private int enemiesPerWave = 5;     // Enemigos al inicio de cada oleada
    private int enemiesSpawned = 0;     // Contador de enemigos generados en la oleada actual
    private bool spawningWave = false;  // ¿Se está generando una oleada?

    public float spawnInterval = 0.5f;  // Tiempo entre spawns individuales
    private float spawnTimer;           // Temporizador interno para el siguiente spawn

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de enemigos vivos

    void Start()
    {
        waveTimer = waveDelay;          // Inicializa el temporizador entre oleadas
    }

    void Update()
    {
        // Si no estamos generando una oleada, verifica si todos los enemigos fueron derrotados
        if (!spawningWave)
        {
            if (activeEnemies.Count == 0) // Verifica si no quedan enemigos vivos
            {
                waveTimer -= Time.deltaTime;
                if (waveTimer <= 0f)
                {
                    StartWave();        // Inicia una nueva oleada
                }
            }
        }
        else
        {
            // Generar enemigos durante la oleada
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f && enemiesSpawned < enemiesPerWave)
            {
                SpawnEnemy();
                spawnTimer = spawnInterval;  // Reinicia el temporizador de spawn
            }

            // Verifica si se generaron todos los enemigos de esta oleada
            if (enemiesSpawned >= enemiesPerWave)
            {
                spawningWave = false;       // Finaliza la generación de esta oleada
                waveTimer = waveDelay;      // Reinicia el tiempo de espera para la siguiente oleada
                currentWave++;              // Incrementa el número de oleada
                enemiesPerWave += 5;        // Aumenta la cantidad de enemigos en la siguiente oleada
            }
        }
    }

    void StartWave()
    {
        enemiesSpawned = 0;                 // Resetea el contador de enemigos generados
        spawningWave = true;               // Activa el modo generación
        spawnTimer = 0f;                   // Comienza a generar enemigos de inmediato
        Debug.Log("Oleada " + currentWave + " comenzando...");
    }

    void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position; // Genera alrededor del jugador

        GameObject newEnemy = Instantiate(enemyPrefab); // Instancia un enemigo
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemigo>().SetTarget(player); // Asigna el jugador como objetivo
        newEnemy.transform.parent = transform; // Organiza los enemigos en el Hierarchy

        activeEnemies.Add(newEnemy); // Agrega el enemigo a la lista de enemigos activos
        enemiesSpawned++; // Incrementa el contador de enemigos generados
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy); // Elimina el enemigo de la lista cuando muere
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = Random.value > 0.5f ? -1f : 1f;

        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;
        return position;
    }
    /*
    public GameObject enemy;
    public Vector2 spawnArea;
    public float spawnTimer;
    private float timer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {   
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemigo>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = Random.value > 0.5f ? -1f : 1f;

        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else 
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
    */
}
