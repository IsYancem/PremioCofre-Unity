using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private Jogador jogador;
    public Renderer fondo;
    public Cofre cofre;
    public GameObject youWinObject;
    public GameObject col1;
    public GameObject coinPrefab; 
    public GameObject playButton;
    public int puntuacion { get; private set; }
    private List<GameObject> monedas = new List<GameObject>(); 

    private void Start()
    {
        jogador = GameObject.FindObjectOfType<Jogador>();
        if (jogador != null)
        {
            Time.timeScale = 0f;
            jogador.enabled = false;
        }
        else
        {
            Debug.LogError("Jogador component not found in the scene");
        }
    }

    public void Play()
    {
        youWinObject.SetActive(false); // Asegura que el objeto YouWin esté desactivado al inicio del juego
        cofre.CerrarCofre(); // Asegura que el cofre esté cerrado al inicio del juego
    
        puntuacion = 0;
        scoreText.text = puntuacion.ToString();
        playButton.SetActive(false);
        Time.timeScale = 1f;
        jogador.enabled = true;

        // Crear monedas y obstáculos
        // ...
        // Crear Techo
        for (float i = 0; i < 34; i++)
        {
            Instantiate(col1, new Vector2(-10 + (i * 0.6f), 7), Quaternion.identity);
        }

        // Crear Pared
        for (float i = 0; i < 14; i++)
        {
            // Izquierda
            Instantiate(col1, new Vector2(-8.6f, 5.62f - (i * 0.6f)), Quaternion.identity);
            Instantiate(col1, new Vector2(-9.2f, 5.62f - (i * 0.6f)), Quaternion.identity);
            Instantiate(col1, new Vector2(-9.8f, 5.62f - (i * 0.6f)), Quaternion.identity);

            // Derecha
            Instantiate(col1, new Vector2(8.6f, 5.61f - (i * 0.6f)), Quaternion.identity);
            Instantiate(col1, new Vector2(9.2f, 5.61f - (i * 0.6f)), Quaternion.identity);
            Instantiate(col1, new Vector2(9.8f, 5.61f - (i * 0.6f)), Quaternion.identity);
        }

        // Crear Suelo
        for (float i = 0; i < 34; i++)
        {
            Instantiate(col1, new Vector2(-10 + (i * 0.6f), -3.5f), Quaternion.identity);
        }

        // Crear 3 monedas al iniciar
        for (int i = 0; i < 3; i++)
        {
            CrearNuevaMoneda(new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-3.0f, 5.0f)));
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        jogador.enabled = false;
    }

    public void AgregarPunto()
    {
        puntuacion = puntuacion + 100;
        scoreText.text = puntuacion.ToString();
        if (puntuacion >= 200)
        {
            Victory();
        }
    }

    public void CrearNuevaMoneda(Vector2 posicionAnterior)
    {
        // Solo crear una nueva mon    eda si hay menos de 3 en el escenario
        if (monedas.Count < 3)
        {
            Vector2 nuevaPosicion;
            do
            {
                nuevaPosicion = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-3.0f, 5.0f));
            } while (nuevaPosicion == posicionAnterior);

            GameObject nuevaMoneda = Instantiate(coinPrefab, nuevaPosicion, Quaternion.identity);
            monedas.Add(nuevaMoneda);
        }
    }

    public void EliminarMoneda(GameObject moneda)
    {
        monedas.Remove(moneda);
    }

    public void Victory()
    {
        youWinObject.SetActive(true); // Activar el objeto YouWin
        cofre.AbrirCofre(); // Abrir el cofre cuando el jugador gana
        //Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (youWinObject.activeSelf)
            {
                Play();
            }
        }
    }
}

