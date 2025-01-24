using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    int velocidad;
    float posX,posY;
    // Start se ejecuta una vez al inciar
    void Start()
    {
        velocidad = 5;
        Debug.Log(velocidad);
    }

    // Update se ejecuta todo el tiempo a la maxima velocidad disponible
    void Update()
    {
        posX = Random.Range(0, 5);
        Debug.Log(posX);
    }
}
