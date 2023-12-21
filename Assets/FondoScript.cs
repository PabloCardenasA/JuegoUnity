using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FondoScript : MonoBehaviour
{
    private Vector3 posInicio;
    public float speed = 1;

    void Start()
    {
        posInicio = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < posInicio.y - 10.5)
        {
            transform.position = posInicio;
        }
    }
}
