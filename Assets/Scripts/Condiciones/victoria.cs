using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoria: MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si la colisión entra en el trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el trigger.");
            // Realizar acciones adicionales si es necesario
        }
    }
    void Update()
    {
      
    }
}
