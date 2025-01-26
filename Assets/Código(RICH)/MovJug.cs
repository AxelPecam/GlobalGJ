using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJug : MonoBehaviour
{
    public Rigidbody2D thRB;
    public float moveSpeed;
    private Vector3 movement;
    private Animator anim;
    private bool facingRight;
    public Transform pistol;

    // Start is called before the first frame update
    void Start()
    {
        thRB = GetComponent<Rigidbody2D>();
        movement = new Vector3();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool isMoving = movement.magnitude > 0;
        anim.SetBool("isMoving", isMoving);


        movement *= moveSpeed;
        thRB.velocity = movement;

        FlipSprite();
    }

    private void FixedUpdate()
    {
        thRB.velocity = movement.normalized * moveSpeed;
    }

    private void FlipSprite()
    {
        if(movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if(movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        if (pistol != null)
        {
            Vector3 pistolScale = pistol.localScale;
            pistolScale.x *= -1;
            pistol.localScale = pistolScale;

            // Ajustamos su posición para que se mantenga en el lado correcto
            Vector3 pistolPosition = pistol.localPosition;
            pistolPosition.x *= -1;
            pistol.localPosition = pistolPosition;
        }
    }
}
