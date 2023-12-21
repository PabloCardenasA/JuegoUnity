using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTipo2Script : MonoBehaviour
{

    public int puntosVida = 1;
    public float speed = 3f;
    private int puntos = 1;
    private PuntajeScript puntaje;

    public AudioSource Reproductor;
    public AudioClip Sonido;

    void Start()
    {
         puntaje = FindObjectOfType<PuntajeScript>();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Disparo"))
        {
            puntosVida--;
            Destroy(other.gameObject);
            if (puntosVida <= 0)
            {
                DestruirEnemigo();
                puntaje.SumarPuntos(puntos);
            }
        }
    }

    void DestruirEnemigo()
    {
        Reproductor.PlayOneShot(Sonido, 0.5f);
        Destroy(gameObject,0.15f);
    }
}
