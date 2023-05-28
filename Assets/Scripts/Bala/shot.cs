using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player_pos;
    public float speed=6f;
    public float distancia_frenado=8f;
    public float distancia_retraso=6f;
    
    public bool miraDerecha = false;
    public bool miraIzquierda = false;

    //Bala
    public Transform punto_instancia;
    public GameObject balaPrefab;
    public float balaSpeed = 10f;
    public float balaDestroyDistance = 50f;
    private float tiempo;
    void Start()
    {
        player_pos=GameObject.Find("Player").transform;   
    }


    
    // Update is called once per frame
    void Update()
    {

            float calc=player_pos.position.x-this.transform.position.x;
            //Debug.Log(calc);

        #region 
        // if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado){
        //    // transform.position=Vector2.MoveTowards(transform.position,player_pos.position,speed*Time.deltaTime);
        //     transform.Translate(Vector2.right * speed * Time.deltaTime);
        // }
        // if(Vector2.Distance(transform.position, player_pos.position)<distancia_retraso){
        //     transform.Translate(Vector2.left * speed * Time.deltaTime);
        // }
        // if(Vector2.Distance(transform.position, player_pos.position)<distancia_frenado && Vector2.Distance(transform.position, player_pos.position)>distancia_retraso){
        //     transform.position=transform.position;
        // }
        #endregion

        //flip
        #region 

        if(player_pos.position.x>this.transform.position.x && player_pos.position.x-this.transform.position.x >= 8){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
            //this.transform.localScale=new Vector2(1,1);
        }else if(player_pos.position.x>this.transform.position.x && player_pos.position.x-this.transform.position.x <= 4 || player_pos.position.x-this.transform.position.x >= 0){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            miraDerecha=true;
            miraIzquierda=false;
          
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if(player_pos.position.x<this.transform.position.x && player_pos.position.x-this.transform.position.x <= -8){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            
            //this.transform.localScale=new Vector2(-1,1);
        }else if(player_pos.position.x<this.transform.position.x && player_pos.position.x-this.transform.position.x >= -4 || player_pos.position.x-this.transform.position.x <= 0){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            miraDerecha=false;
            miraIzquierda=true;
            
            transform.localScale = new Vector3(-1, 1, 1);
        }

        #endregion


        tiempo += Time.deltaTime;
if (tiempo >= 2)
{
    GameObject bala = Instantiate(balaPrefab, punto_instancia.position, Quaternion.identity);
    Rigidbody2D balaRb = bala.GetComponent<Rigidbody2D>();
    if (balaRb != null)
    {
        if (miraDerecha)
        {
            // aplicar fuerza a la bala para moverla
       
            balaRb.AddForce(transform.right * balaSpeed, ForceMode2D.Impulse);
        }
        else if (miraIzquierda)
        {
            // aplicar fuerza a la bala para moverla
            
            balaRb.AddForce(-transform.right * balaSpeed, ForceMode2D.Impulse);
        }
    }

    // destruir la bala después de cierta distancia
    Destroy(bala, balaDestroyDistance / balaSpeed);

    tiempo = 0;
}

    }
    
public void TakeDamage(){
        Destroy(gameObject);
    }

}
