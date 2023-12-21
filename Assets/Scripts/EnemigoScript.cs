using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class EnemigoScript : MonoBehaviour
{
    public int puntosVida = 3;
    public float speed = 2f;
    public float maxY = 8f; 
    public float minY = 2.5f;
    public GameObject disparoEnemigo;
    private int puntos = 10;
    private PuntajeScript puntaje;
    private int direction = 1;
    private bool disparoDisponible = true;

    public AudioSource Reproductor;
    public AudioClip Sonido;

    void Start()
    {
         puntaje = FindObjectOfType<PuntajeScript>();
    }
    void Update()
    {
        MoveEnemy();
        
        if (transform.position.y <= minY)
        {
            speed = 0f;
            Invoke("CambioDireccion", 1f);
            Disparar();
        }
        else if (transform.position.y >= maxY)
        {
            DestruirEnemigo();
        }
    }

    void MoveEnemy()
    {
        transform.Translate(Vector2.down * direction * speed * Time.deltaTime);
    }

    void CambioDireccion()
    {
        direction = -1;
        speed = 2f; 
    }

    void Disparar()
    {   
        if (disparoDisponible)
        {
            Debug.Log("Disparo");
            Vector3 puntoDisparo = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            GameObject disparo = Instantiate(disparoEnemigo, puntoDisparo, quaternion.identity);
            Destroy(disparo, 2f);
            disparoDisponible = false;
        }
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
