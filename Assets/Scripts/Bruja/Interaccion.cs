using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{

    bool enColision = false;
    public string mensaje;
    //public Text mensaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void OnTriggerEnter2D(Collider2D colision) {
        if (colision.CompareTag("Player")) {
            Debug.Log("Entro");
            enColision = true;
            mensaje = "Presiona 'E' para comprar";
        }
    }

    void OnTriggerExit2D(Collider2D colision) {
        if (colision.CompareTag("Player")) {
            Debug.Log("Salgo");
            enColision = false;
            mensaje = "";
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(enColision){
               if (Input.GetKeyDown(KeyCode.E)){
                    //Abrir tienda
                }
        }
  
    }
}
