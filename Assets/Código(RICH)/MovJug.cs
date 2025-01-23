using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJug : MonoBehaviour
{
    public Rigidbody2D thRB;
    public float moveSpeed;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        thRB = GetComponent<Rigidbody2D>();
        movement = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement *= moveSpeed;
        thRB.velocity = movement;
    }
}
