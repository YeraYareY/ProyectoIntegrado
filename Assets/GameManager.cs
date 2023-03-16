using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int PuntosTotales{ get { return puntosTotales; } }
    private int puntosTotales;


    void Start(){

    }
    public void sumarPuntos(int puntosASumar){
        this.puntosTotales+=puntosASumar;
        Debug.Log(puntosTotales);
    }
    // Update is called once per frame
    void Update(){

    }
}
