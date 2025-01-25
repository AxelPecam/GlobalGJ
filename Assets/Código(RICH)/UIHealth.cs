using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image heartImage; // Imagen del coraz�n
    public PlayerHealth playerHealth; // Referencia al script de salud del jugador

    private void Update()
    {
        if (playerHealth != null && heartImage != null)
        {
            // Calcular el porcentaje de salud
            float healthPercentage = (float)playerHealth.currentHealth / playerHealth.maxHealth;

            // Actualizar el fill amount del coraz�n
            heartImage.fillAmount = healthPercentage;

            // Si la salud es 0, desactivar la imagen del coraz�n
            if (playerHealth.currentHealth <= 0)
            {
                heartImage.gameObject.SetActive(false);
            }
        }
    }
}
       

