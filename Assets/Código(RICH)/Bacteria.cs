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

    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
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
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage();
        }
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
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Character>())
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}
