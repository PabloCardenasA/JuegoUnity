using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float tiempoDeEspera = 2f;
    public float rangoSpawn = 5f; 
    public float tiempoTotal = 120f;
    private float tiempoTranscurrido = 0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemigo", 2f, tiempoDeEspera);
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoTotal)
        {
            CancelInvoke("SpawnEnemigo");
        }
    }

    void SpawnEnemigo()
    {
        Vector3 posicionAleatoria = transform.position + UnityEngine.Random.insideUnitSphere * rangoSpawn;
        posicionAleatoria.y = transform.position.y;
        Instantiate(enemigoPrefab, posicionAleatoria, Quaternion.identity);
    }
}
