using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad de movimiento hacia arriba

    private float tiempoInicio;
   

    void Update()
    {

            
            float tiempoTranscurrido = Time.time - tiempoInicio;
            float desplazamiento = velocidad;

            // Mover el objeto hacia arriba en incrementos pequeños
            transform.Translate(Vector3.up * desplazamiento);

        
    }

    
}
