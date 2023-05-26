using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class derrota : MonoBehaviour
{
    [SerializeField] public GameObject menuGameOver;
    public GameObject jugador;
    public int vida;
    private void Start(){
        vida=jugador.GetComponent<player>().vida;
        menuGameOver.SetActive(false);
        
    }
    private void Update(){
        vida=jugador.GetComponent<player>().vida;
        if(vida<=0){
            GetComponent<player>().enabled = false;
            menuGameOver.SetActive(true);
        }
        
    }
    // Update is called once per frame
}
