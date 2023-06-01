using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocidad; 

    private Rigidbody2D rb;
    private Animator anim;
    private bool mirandoDerecha = true; // Nueva variable para determinar hacia donde mira el personaje

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Mover al jugador a la izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            if (mirandoDerecha)
            {
                Flip();
            }
        }

        // Mover al jugador a la derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            if (!mirandoDerecha)
            {
                Flip();
            }
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJump", true);
            rb.AddForce(new Vector2(0, fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            anim.SetBool("isJump", false);
        }
    }

    // Nueva función para voltear el personaje
    void Flip()
    {
        mirandoDerecha = !mirandoDerecha; 
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
