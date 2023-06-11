using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interaccion : MonoBehaviour
{

    bool enColision = false;
    public string mensaje;
    public GameObject panelTienda;
     public TextMeshProUGUI textoMensaje;
    public GameObject[] itemInStore;
    public player player;
    public TextMeshProUGUI puntuacionHUD;
    public Image vidaHUD;

    //public Text mensaje;
    // Start is called before the first frame update
    void Start()
    {
        panelTienda.SetActive(false);
    }

   
    void OnTriggerEnter2D(Collider2D colision) {
        if (colision.CompareTag("Player")) {
            enColision = true;
            mensaje = "Presiona 'E' para comprar";   
            textoMensaje.text=player.puntos+"";   
            
        }else{
            panelTienda.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D colision) {
        if (colision.CompareTag("Player")) {
            enColision = false;
            mensaje = "";
            panelTienda.SetActive(false);
            puntuacionHUD.enabled=true;
        
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        textoMensaje.text=player.puntos+""; 
    
        if(enColision){
               if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire3")){
                    panelTienda.SetActive(true);
                    puntuacionHUD.enabled=false;  
                }
        }
  
    }
}
