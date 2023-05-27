using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
  
    public GameObject Jugador;
    
    // Update is called once per frame
    void Start(){
       
       
    }
    void Update()
    {
        Vector3 position=transform.position;
        position.x=Jugador.transform.position.x;
        transform.position=position;
    }
}
