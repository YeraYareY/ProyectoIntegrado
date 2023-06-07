using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarVariable : MonoBehaviour
{
    // Start is called before the first frame update
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
            Letras.texto="Parece que te adaptas bien! Mira aqui tienes una bruja, podras comercias con ellas y conseguir objetos que te ayudaran en tu aventura! Pulsa E para interactuar";
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
