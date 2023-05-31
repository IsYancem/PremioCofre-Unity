using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    //public GameManager gameManager;
    public float fuerzaSalto;
    //public int vida = 500;  // Nueva variable para las vidas del jugador

    private Rigidbody2D rb;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    
}
