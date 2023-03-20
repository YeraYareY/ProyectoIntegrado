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

    public Transform punto_instancia;
    public GameObject bala;
    private float tiempo;
    void Start()
    {
        player_pos=GameObject.Find("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        #region 
        if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado){
            transform.position=Vector2.MoveTowards(transform.position,player_pos.position,speed*Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, player_pos.position)<distancia_retraso){
            transform.position=Vector2.MoveTowards(transform.position,player_pos.position,-speed*Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, player_pos.position)<distancia_frenado && Vector2.Distance(transform.position, player_pos.position)>distancia_retraso){
            transform.position=transform.position;
        }
        #endregion

        //flip
        #region 

        if(player_pos.position.x>this.transform.position.x){
            this.transform.localScale=new Vector2(1,1);
        }else{
            this.transform.localScale=new Vector2(-1,1);
        }

        #endregion


        tiempo+=Time.deltaTime;
        if(tiempo>=2){
           Instantiate(bala,punto_instancia.position,Quaternion.identity);
           tiempo=0;
        }

    }
}
