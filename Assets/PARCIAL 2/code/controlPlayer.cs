using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPlayer : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    public float velPlayer=10f;//velocidad del player
    public float jumpForce=100f;//fuerza de brinco
    bool brincando;
    public GameObject balaprefab;
    Vector2 movPlayer;
    public Transform spawnBala;
    
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();//Obtenemos el RB para movernos
    }

    void Update()
    {
        movPlayer = new Vector2(Input.GetAxis("Horizontal") * velPlayer, rbPlayer.velocity.y);
        rbPlayer.velocity = movPlayer;

        if (Input.GetAxis("Horizontal") != 0)
        {
            
            if(Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale=new Vector3(1, 1, 1);
                
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                
            }
        }
       

        if (Input.GetKeyDown(KeyCode.F))
        {
            ataquePlayer();
        }

    }

    public void ataquePlayer()
    {
        GameObject bala=Instantiate(balaprefab, spawnBala.position, Quaternion.identity);
    }
}
