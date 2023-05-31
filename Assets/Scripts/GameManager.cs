using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject col1;

    private void Start()
    {
        // Crear Mapa
        for (float i = 0; i < 41; i++)
        {
            Instantiate(col1, new Vector2(-10 + (i * 0.6f), -3), Quaternion.identity);
            Instantiate(col1, new Vector2(-8, (i * -0.6f)), Quaternion.identity);
        }
    }

    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
    }
}
