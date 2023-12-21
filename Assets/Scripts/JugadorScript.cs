using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Mathematics;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public GameObject disparoPrefab;
    public float speed = 5f;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    public float frecuenciaDisparo = 0.25f;
    private float temporizadorDisparo = 0f;
    public GameOver controladorGameover;

    public AudioSource Reproductor;
    public AudioClip Sonido;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        temporizadorDisparo += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space) && temporizadorDisparo >= frecuenciaDisparo)
        {
            Disparar();
            temporizadorDisparo = 0f;
        }
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void Disparar()
    {
        Vector3 puntoDisparo = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        GameObject disparo = Instantiate(disparoPrefab, puntoDisparo, quaternion.identity);
        Destroy(disparo, 2f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DisparoEnemigo"))
        {
            Destroy(other.gameObject);
            Muerte();
        }
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            Muerte();
        }
    }
    
    void Muerte()
    {
        Reproductor.PlayOneShot(Sonido, 0.5f);
        Destroy(gameObject,0.1f);
        controladorGameover.jugadorMuerto = true;
        controladorGameover.MostrarGameOverPorMuerte();
    }
}
