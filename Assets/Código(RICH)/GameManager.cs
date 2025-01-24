using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int balas ;
    public TextMeshProUGUI textopuntos;
    void Start()
    {
        textopuntos.text = "Balas: " + balas ;
    }
    private void Update()
    {
        if (balas >= 100) 
        {
            balas = 100;
        }
    }
    public void restarbalas(int p)
    {
        balas -= p ;
        textopuntos.text = "Balas: " +  balas;
    }
}
