using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntajeScript : MonoBehaviour
{
    private float puntos = 0f;
    private TextMeshProUGUI textMesh;
    private TextMeshProUGUI puntajeGameover;
    public GameObject pantallaGameover;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        puntajeGameover = pantallaGameover.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = puntos.ToString("0");
        puntajeGameover.text = "Puntaje Obtenido: " + puntos.ToString("0");
    }

    public void SumarPuntos(int puntosObtenidos)
    {
        puntos += puntosObtenidos;
    }
}
