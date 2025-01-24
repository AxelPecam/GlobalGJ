using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public float fondo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        fondo -= 2 *Time.deltaTime;
        transform.position = new Vector2(transform.position.x, fondo);
        if (fondo <= -6)
        {
            fondo = 6;
        }
      
    }
}
