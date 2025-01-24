using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasito : MonoBehaviour
{
    public Transform targetDestination;
    [SerializeField] private float speed = 5f; // Velocidad alta
    public int health = 5; // Resistencia (más disparos para destruirlo)
    public Rigidbody2D rb;
    public GameObject explosionEffect; // Efecto visual para la explosión
    public float explosionRadius = 2f; // Radio de explosión
    public int explosionDamage = 20; // Daño al jugador

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode(); // Explota al tocar al jugador
        }
    }

    private void Explode()
    {
        // Crear un efecto de explosión (opcional)
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
                /*
                // Suponiendo que el jugador tiene un script para recibir daño
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(explosionDamage);
                }
                */
            }
        }

        // Destruir el enemigo después de la explosión
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el radio de explosión en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
