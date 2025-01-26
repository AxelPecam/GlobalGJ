using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int currentAmmo = 10;  // Valor inicial de munición
    public TextMeshProUGUI ammoText;  // UI para mostrar la munición

    void Start()
    {
        // Asegúrate de tener el texto de la munición asignado en la UI
        if (ammoText != null)
        {
            UpdateAmmoDisplay();
        }
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        UpdateAmmoDisplay(); // Actualiza la UI
    }

    private void UpdateAmmoDisplay()
    {
        ammoText.text = "Balas: " + currentAmmo;
    }
}
