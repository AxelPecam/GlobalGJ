using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class federico : MonoBehaviour
{
    public float velocidad;
    float posicion;
    Rigidbody2D rbfederico;

    // Start is called before the first frame update
    void Start()
    {
      rbfederico=GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        posicion = Input.GetAxis("Vertical");
        rbfederico.velocity = new Vector2(0,posicion * velocidad);
        
    }

   

}
