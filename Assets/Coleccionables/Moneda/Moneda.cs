using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update
    public int valor=100;
    public GameManager gameManager;
    public AudioSource sonido;
    public player player;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            sonido.Play();
            gameManager.sumarPuntos(valor);
            player.puntos+=valor;
            Invoke("DestruirObjeto", 0.1f);
            
            
            //gameManager.sumarPuntos(valor);
        }
    }

    void DestruirObjeto(){
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
