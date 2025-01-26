using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recarga : MonoBehaviour
{
    public int balas;
    public TextMeshProUGUI textopuntos;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        balas += 2;
        textopuntos.text = "Balas: " + balas;
    }
}
