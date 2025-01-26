using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasito : MonoBehaviour
{
    public Transform targetDestination;
    [SerializeField] private float speed = 5f; // Velocidad alta
    public int health = 5; // Resistencia (m�s disparos para destruirlo)
    public Rigidbody2D rb;
    public GameObject explosionEffect; // Efecto visual para la explosi�n
    public float explosionRadius = 2f; // Radio de explosi�n
    public int explosionDamage = 20; // Da�o al jugador
    private EnemiesManager enemiesManager; // Referencia al administrador de enemigos
    public GameObject deathEffectPrefab; // Prefab del efecto de muerte
    public GameObject VidaDrop;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemiesManager = GetComponent<EnemiesManager>();
    }

    public void SetTarget(GameObject target)
    {
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (targetDestination != null)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            rb.velocity = direction * speed; // Movimiento hacia el jugador
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--; // Reduce la salud al ser golpeado
            Destroy(other.gameObject); // Destruye el proyectil
            if (health <= 0)
            {
                Explode(); // Explota al ser destruido
                FindObjectOfType<EnemiesManager>().EnemyDefeated(); // Notifica al EnemiesManager que este enemigo fue derrotado
                GameObject Vida = Instantiate(VidaDrop, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20); // Causa 10 de da�o al jugador
            }

    }   }

    private void NotifyManagerAndDestroy()
    {
        enemiesManager.RemoveEnemy(gameObject); // Notifica al administrador que este enemigo muri�
        Destroy(gameObject); // Destruye al enemigo
    }
    private void Explode()
    {
        // Crear un efecto de explosi�n (opcional)
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar objetos cercanos (por ejemplo, el jugador)
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {   
                
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(explosionDamage);
                }
                
            }
        }

        // Destruir el enemigo despu�s de la explosi�n
        Destroy(gameObject);
    }

    private void Die()
    {
        // Instanciar el efecto de muerte
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);    
        }
        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el radio de explosi�n en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
