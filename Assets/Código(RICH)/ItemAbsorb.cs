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

    public ItemType itemType;  // Tipo de item (salud o munici�n)
    public int value = 1;  // Valor de salud o munici�n a aumentar

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
                    playerHealth.Heal(value);  // M�todo que suma salud al jugador
                    Destroy(gameObject);  // Destruir el �tem despu�s de ser absorbido
                }
            }

            if (playerAmmo != null)
            {
                if (itemType == ItemType.Ammo)
                {
                    playerAmmo.AddAmmo(value);  // M�todo que suma munici�n al jugador
                    Destroy(gameObject);  // Destruir el �tem despu�s de ser absorbido
                }
            }
        }
    }
}
