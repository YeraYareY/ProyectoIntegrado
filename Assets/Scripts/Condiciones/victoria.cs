using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoria: MonoBehaviour
{
    public GameObject vict;
   void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si la colisión entra en el trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el trigger.");
            vict.SetActive(true);
            // Realizar acciones adicionales si es necesario
        }
    }
    void Start()
    {
      vict.SetActive(false);
    }
}
