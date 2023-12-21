using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject pantallaGameOver;
    public bool jugadorMuerto = false;
    public float tiempoDeJuego = 63f;

    void Update()
    {
        tiempoDeJuego -= Time.deltaTime;
        if(tiempoDeJuego < 0)
        {
            MostrarPantallaGameOver();
        }
    }

    public void MostrarGameOverPorMuerte()
    {
        MostrarPantallaGameOver();
    }

    void MostrarPantallaGameOver()
    {
        pantallaGameOver.SetActive(true);
    }

    // Método para reiniciar la escena
    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para volver al menú principal
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuInicio"); // Cambia "MenuPrincipal" al nombre de tu escena principal
    }
}

