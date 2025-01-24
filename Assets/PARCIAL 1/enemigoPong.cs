using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoPong : MonoBehaviour
{
    public Transform posPelota;//Declaramos la posición de la pelota
    Vector2 destino;
    public float velEnemigo;

    void Update()
    {
        //Aqui va el enemigo con velocidad
        destino= new Vector2(transform.position.x,posPelota.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destino,Time.deltaTime * velEnemigo);

        //Esto hace que sigamos todo el tiempo en Y a la pelota
        //Este es un enemigo perfecto, es imposible anotar
        //transform.position = new Vector2(transform.position.x,posPelota.position.y);
    }
}
