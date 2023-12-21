using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour

{
    private float tiempoDeEspera = 5f;

    void Start()
    {
        Invoke("DestruirObjeto", tiempoDeEspera);
    }

    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
