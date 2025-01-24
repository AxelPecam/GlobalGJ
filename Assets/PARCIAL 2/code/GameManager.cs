using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI textopuntos;
    void Start()
    {
        textopuntos.text = "Puntos: " + puntos ;
    }
    private void Update()
    {
        if (puntos >= 1700) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void sumarpuntos(int p)
    {
        puntos += p ;
        textopuntos.text = "Puntos: " + puntos;
    }
}
