using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoBala : MonoBehaviour
{

    private shot claseShot=new shot();
    public Transform punto_instancia;
    public GameObject balaPrefab;
    public float balaSpeed = 10f;
    public float balaDestroyDistance = 50f;
    private float tiempo;
    public bool miraDerecha = false;
    public bool miraIzquierda = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Player")){
            Debug.Log("COLISION");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        miraDerecha=claseShot.miraDerecha;
        miraIzquierda=claseShot.miraIzquierda;

        tiempo+=Time.deltaTime;
        if(tiempo>=2){

            GameObject bala = Instantiate(balaPrefab, punto_instancia.position, Quaternion.identity);
            Rigidbody2D balaRb = bala.GetComponent<Rigidbody2D>();
            if(balaRb != null){
                if(miraDerecha){
                    // aplicar fuerza a la bala para moverla
                    balaRb.AddForce(transform.right * balaSpeed, ForceMode2D.Impulse);
                }else if(miraIzquierda){
                    // aplicar fuerza a la bala para moverla
                    balaRb.AddForce(-transform.right * balaSpeed, ForceMode2D.Impulse);
                }
            }
            tiempo = 0;
        }
    }
    
}
