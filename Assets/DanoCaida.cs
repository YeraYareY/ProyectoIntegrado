using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoCaida : MonoBehaviour
{


    public GameObject jugador; // Referencia al objeto del jugador
    public float distanciaMaxima = 10f; // Distancia máxima permitida
    private int vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 posicionJugador = jugador.transform.position;

        // Verificar si el jugador ha caído más allá de la distancia máxima
        if (posicionJugador.y < -distanciaMaxima)
        {
            jugador.GetComponent<player>().vida -= 3;
            Debug.Log(this.vida);   
            // Aquí puedes agregar cualquier otra lógica que necesites
        }
    }
}
