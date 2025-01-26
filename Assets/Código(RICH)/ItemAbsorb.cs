using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbsorb : MonoBehaviour
{
    public enum ItemType
    {
        Health,
        Ammo
    }

    public ItemType itemType;  // Tipo de item (salud o munición)
    public int value = 1;  // Valor de salud o munición a aumentar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener los componentes del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            Recarga playerAmmo = other.GetComponent<Recarga>();  // Ahora buscamos PlayerAmmo

            if (playerHealth != null)
            {
                if (itemType == ItemType.Health)
                {
                    playerHealth.Heal(value);  // Método que suma salud al jugador
                    Destroy(gameObject);  // Destruir el ítem después de ser absorbido
                }
            }

            if (playerAmmo != null)
            {
                if (itemType == ItemType.Ammo)
                {
                    playerAmmo.AddAmmo(value);  // Método que suma munición al jugador
                    Destroy(gameObject);  // Destruir el ítem después de ser absorbido
                }
            }
        }
    }
}
