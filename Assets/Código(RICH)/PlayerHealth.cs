using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Salud del Jugador")]
    public int maxHealth = 100; // Salud m�xima
    public int currentHealth; // Salud actual

    [Header("Efectos de Da�o")]
    public GameObject damageEffect; // Efecto visual al recibir da�o
    public float damageEffectDuration = 0.2f; // Duraci�n del efecto

    private bool isInvincible = false; // Evitar recibir da�o repetido r�pidamente
    public float invincibilityTime = 1f; // Tiempo de invencibilidad tras recibir da�o
    [Header("Death Effect")]
    public GameObject deathEffectPrefab; // Prefab del efecto de muerte
    private void Start()
    {
        // Iniciar con la salud m�xima
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return; // Ignorar da�o si el jugador es invencible

        currentHealth -= damage; // Reducir salud
        Debug.Log("Salud del jugador: " + currentHealth);

        // Activar efecto visual de da�o (opcional)
        if (damageEffect != null)
        {
            StartCoroutine(ShowDamageEffect());
        }

        // Verificar si el jugador muri�
        if (currentHealth <= 0)
        {
            Die();
        }

        // Activar invencibilidad por un tiempo
        StartCoroutine(Invincibility());
    }

    private IEnumerator ShowDamageEffect()
    {
        // Mostrar el efecto visual de da�o
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(damageEffectDuration);
        damageEffect.SetActive(false);
    }

    private IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    private void Die()
    {
        // Instanciar el efecto de muerte
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destruir al jugador (o desactivarlo)
        Destroy(gameObject);

        // Mostrar un mensaje de "Game Over"
        Debug.Log("Game Over");
    }
    public void Heal(int amount)
    {
        // Curar al jugador (sin exceder la salud m�xima)
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Salud del jugador tras curar: " + currentHealth);
    }
}
