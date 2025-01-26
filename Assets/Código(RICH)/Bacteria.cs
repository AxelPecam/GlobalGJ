using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    public Transform targetDestination;
    [SerializeField] private float speed = 1.5f;
    public Rigidbody2D theRB;
    public GameObject targetGameObject;

    [SerializeField] private int health = 4;
    private EnemiesManager enemiesManager; // Referencia al administrador de enemigos
    [Header("Death Effect")]
    public GameObject deathEffectPrefab; // Prefab del efecto de muerte
    public GameObject BalaDrop;
    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        enemiesManager = GetComponent<EnemiesManager>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;

        if (targetDestination != null)
        {
            Debug.Log("Target asignado correctamente: " + targetDestination.name);
        }
        else
        {
            Debug.LogError("Error: No se pudo asignar el target.");
        }
    }

    private void FixedUpdate()
    {
        if(targetDestination != null)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            theRB.velocity = direction * speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<EnemiesManager>().EnemyDefeated(); // Notifica al EnemiesManager que este enemigo fue derrotado
            TakeDamage();
        }
    }

    private void NotifyManagerAndDestroy()
    {
        enemiesManager.RemoveEnemy(gameObject); // Notifica al administrador que este enemigo murió
        Destroy(gameObject); // Destruye al enemigo
    }
    private void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Instanciar el efecto de muerte
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            GameObject Recarga = Instantiate(BalaDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(15); // Causa 10 de daño al jugador
            }
    }   }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}
