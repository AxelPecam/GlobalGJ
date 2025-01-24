using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movEnemigo : MonoBehaviour
{
    float posx; 
    public float velx;
    public float rango;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position=new Vector2 (transform.position.x+posx, transform.position.y);
        posx += velx;
        if(posx>rango || posx < (rango*-1)) { velx *= -1; }
    }
}
