using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int PuntosTotales{ get { return puntosTotales; } }
    private int puntosTotales;
    public player player;

    void Start(){

    }
    public void sumarPuntos(int puntosASumar){
        player.puntos+=puntosASumar;
        
    }
    // Update is called once per frame
    void Update(){
    
    }
}
