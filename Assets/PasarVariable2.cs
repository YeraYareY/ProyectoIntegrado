using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarVariable2 : MonoBehaviour
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
            Letras.texto="Vaya! un pueblo, y parece que hay monedas! Con estas monedas podras comprar objetos de la bruja, porque no intentas recoger algunas?";
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
