using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBocchi : MonoBehaviour
{
    public GameObject enemigoPrefab;

    void Start()
    {
        Invoke("SpawnEnemigo", 60f);
    }
    void SpawnEnemigo()
    {
        Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
    }
}
