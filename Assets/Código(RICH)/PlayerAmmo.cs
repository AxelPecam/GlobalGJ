using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int currentAmmo = 10;  // Valor inicial de munici�n
    public TextMeshProUGUI ammoText;  // UI para mostrar la munici�n

    void Start()
    {
        // Aseg�rate de tener el texto de la munici�n asignado en la UI
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
