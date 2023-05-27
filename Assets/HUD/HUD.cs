using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{

    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        puntos.text=player.puntos.ToString();
        
        
        int puntosInt;
        if (int.TryParse(puntos.text, out puntosInt))
        {
            player.puntos = puntosInt; // Asignar el valor entero a la variable puntos en el script player
        }
        else
        {
            Debug.LogError("No se pudo convertir el texto a un número entero.");
        }
    }
}
