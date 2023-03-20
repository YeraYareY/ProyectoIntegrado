using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Rango : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Enemy enemigo;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            //cancelar animacion correr y andar y activar la de atacar
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
