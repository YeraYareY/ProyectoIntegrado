using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Letras : MonoBehaviour
{
 
    public TextMeshProUGUI textoMesh; // Referencia al componente TextMeshPro
    public float velocidadDesplazamiento = 1f; // Velocidad a la que se desplazan las letras
    public float tiempoEntreLetras = 0.5f; // Tiempo de espera entre la aparición de cada letra
    public static string texto = "Bienvenido! primero voy a explicarte los movimientos basicos: W A S D para poder moverte y ESPACIO para saltar, pruebalo!"; // Texto a mostrar
    public static bool variableBooleana;// Condicional a comprobar
    private float tiempoInicio; // Tiempo de inicio para el efecto de aparición
    private float duracionAparicion = 1f; // Duración total del efecto de aparición (en segundos)

    void Start()
    {
        // Obtener la referencia al componente TextMeshPro
        textoMesh = GetComponent<TextMeshProUGUI>();

        // Configurar el texto inicial y la transparencia
        textoMesh.text = texto;
        textoMesh.alpha = 0f;

        // Guardar el tiempo de inicio
        tiempoInicio = Time.time;
    }

    void Update()
    {
        // Mover el objeto contenedor hacia arriba o hacia abajo según la velocidad de desplazamiento
        transform.Translate(Vector3.up * velocidadDesplazamiento * Time.deltaTime);

        // Calcular el tiempo transcurrido desde el inicio
        float tiempoTranscurrido = Time.time - tiempoInicio;

        // Calcular la opacidad en base al tiempo transcurrido
        float opacidad = Mathf.Clamp01(tiempoTranscurrido / duracionAparicion);

        // Aplicar la opacidad al componente TextMeshPro
        textoMesh.alpha = opacidad;

         if(variableBooleana){
            textoMesh.text =texto;
            Debug.Log(texto);
        }
    }
 

}


