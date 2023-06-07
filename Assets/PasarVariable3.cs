using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarVariable3 : MonoBehaviour
{
    public GameObject enemigo;
    void Start()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            Letras.variableBooleana=false;
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            Letras.variableBooleana=true;
            Letras.texto="Ahora te explicare como pelear, pulsa Click izquierdo e intenta eliminar al enemigo mas cercano";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemigo==null){
            Letras.variableBooleana=true;
            Letras.texto="Perfecto! ahora atraviesa el portal que encontras mas adelante, te llevara al inicio de tu aventura!";
            
        }
    }
}
