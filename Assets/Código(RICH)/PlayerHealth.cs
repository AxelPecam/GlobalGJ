using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Salud del Jugador")]
    public int maxHealth = 100; // Salud máxima
    public int currentHealth; // Salud actual

    [Header("Efectos de Daño")]
    public GameObject damageEffect; // Efecto visual al recibir daño
    public float damageEffectDuration = 0.2f; // Duración del efecto

    private bool isInvincible = false; // Evitar recibir daño repetido rápidamente
    public float invincibilityTime = 1f; // Tiempo de invencibilidad tras recibir daño
    [Header("Death Effect")]
    public GameObject deathEffectPrefab; // Prefab del efecto de muerte
    private void Start()
    {
        // Iniciar con la salud máxima
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return; // Ignorar daño si el jugador es invencible

        currentHealth -= damage; // Reducir salud
        Debug.Log("Salud del jugador: " + currentHealth);

        // Activar efecto visual de daño (opcional)
        if (damageEffect != null)
        {
            StartCoroutine(ShowDamageEffect());
        }

        // Verificar si el jugador murió
        if (currentHealth <= 0)
        {
            Die();
        }

        // Activar invencibilidad por un tiempo
        StartCoroutine(Invincibility());
    }

    private IEnumerator ShowDamageEffect()
    {
        // Mostrar el efecto visual de daño
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
        // Curar al jugador (sin exceder la salud máxima)
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Salud del jugador tras curar: " + currentHealth);
    }
}
