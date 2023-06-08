using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBala : MonoBehaviour
{
    public float tiempoDeVida = 3f; // Tiempo de vida en segundos

    private float tiempoCreacion;

    void Start()
    {
        tiempoCreacion = Time.time; // Tiempo de creación del objeto
    }

    void Update()
    {
        float tiempoTranscurrido = Time.time - tiempoCreacion;
        if (tiempoTranscurrido >= tiempoDeVida && gameObject.name!="bala") 
        {
            DestruirObjeto();
        }
        
    }

    void DestruirObjeto()
    {
        // Destruir el objeto
        Destroy(gameObject);
    }
}
