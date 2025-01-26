using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recarga : MonoBehaviour
{
    public int balas;
    public TextMeshProUGUI textopuntos;
    public GameManager gameManager;
    public PlayerAmmo playerAmmo;  // Referencia al sistema de munici�n del jugador

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAmmo = GameObject.FindWithTag("Player").GetComponent<PlayerAmmo>();  // Encuentra el jugador y obtiene su script de munici�n
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAmmo.AddAmmo(2); // A�ade 2 balas al jugador
            Destroy(gameObject);   // Destruye el �tem de munici�n
        }
    }
}
