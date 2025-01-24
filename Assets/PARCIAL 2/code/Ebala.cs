using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ebala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        if (collision.gameObject.CompareTag("suelo"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(gameObject);
        }
    }
}
