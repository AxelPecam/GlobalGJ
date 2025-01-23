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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
=======

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            Attack();
        }
    }

    public void Attack()
    {
        
    }
>>>>>>> Stashed changes
}
