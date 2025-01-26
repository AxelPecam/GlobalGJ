using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemigo : MonoBehaviour
{
    public Transform targetDestination;
    [SerializeField] private float speed;
    public Rigidbody2D rb;
    public GameObject targetGameObject;

    private EnemiesManager enemiesManager; // Referencia al administrador de enemigos
    [Header("Death Effect")]
    public GameObject deathEffectPrefab; // Prefab del efecto de muerte
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemiesManager = FindObjectOfType<EnemiesManager>(); // Busca el script del administrador de enemigos
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (targetDestination != null) {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);   // Destruye la bala
            Die();
            FindObjectOfType<EnemiesManager>().EnemyDefeated(); // Notifica al EnemiesManager que este enemigo fue derrotado
            NotifyManagerAndDestroy();  // Notifica y destruye al enemigo
        }
    }

    private void NotifyManagerAndDestroy()
    {
        enemiesManager.RemoveEnemy(gameObject); // Notifica al administrador que este enemigo murió
        Destroy(gameObject); // Destruye al enemigo
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Causa 10 de daño al jugador
            }
        }
    }
    public void Die()
    {
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destruir al enemigo
        Destroy(gameObject);
    }
}

