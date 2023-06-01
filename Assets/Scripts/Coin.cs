using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;

    private void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Jogador")
        {
            gameManager.AgregarPunto();
            gameManager.EliminarMoneda(gameObject); // Llamada al nuevo método
            gameManager.CrearNuevaMoneda(transform.position);
            Destroy(gameObject); // Destruir el objeto
        }
    }
}