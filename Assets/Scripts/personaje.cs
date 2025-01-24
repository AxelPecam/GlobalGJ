using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tinyurl.com/drolejanm

public class personaje : MonoBehaviour
{
    float posX;// Con esto moveremos al player con transform
    
    //Con estos moveremos al player con fisicas (rigibody 2d)
    float velX;
    Rigidbody2D rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
       rbPlayer=GetComponent<Rigidbody2D>();//Obtengo el rigidbody del objeto 
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento con transform
        posX += Input.GetAxis("Horizontal");//Obtiene el eje horizontal de los Inputs
        Vector2 posPlayer = new Vector2(posX/100,transform.position.y);
        //Comentamos esta para desactivar el movimiento con transform
        //transform.position = posPlayer;

        //Movimiento con RigidBody
        velX = Input.GetAxis("Horizontal")*10;
        rbPlayer.velocity = new Vector2(velX,rbPlayer.velocity.y);
    }
}
