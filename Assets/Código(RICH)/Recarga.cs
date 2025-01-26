using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recarga : MonoBehaviour
{
    public int balas;  // Cantidad de balas del jugador
    public TextMeshProUGUI textopuntos;  // UI para mostrar la cantidad de balas
    public GameManager gameManager;  // Para el manejo de la lógica general del juego
    public int currentAmmo = 10;  // Valor inicial de munición

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("UIHealth").GetComponent<GameManager>();
        balas = currentAmmo;  // Aseguramos que la cantidad inicial de balas sea la que se define al inicio
        UpdateAmmoText();  // Actualizamos el texto del HUD al inicio
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes añadir lógica adicional si necesitas hacer algo con las balas
    }

    public void AddAmmo(int amount)
    {
        balas += amount;  // Aumentar la cantidad de balas
        UpdateAmmoText();  // Actualizamos el texto con la nueva cantidad de balas
        Debug.Log("Munición agregada. Total: " + balas);
    }

    // Método para actualizar el texto del HUD con la cantidad de balas
    private void UpdateAmmoText()
    {
        textopuntos.text = "Balas: " + balas;
    }

    // Cuando el jugador colisiona con un item que recarga munición
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddAmmo(2);  // Por ejemplo, agregar 2 balas al ser recogido el item
            Destroy(gameObject);  // Destruir el item después de ser recogido
        }
    }
}
