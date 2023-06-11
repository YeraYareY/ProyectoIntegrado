using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Enemy : MonoBehaviour
{
    public static bool hit;
    public bool pausado;
    public player player;
    public ParticleSystem particulas;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {

            if(!pausado){
                player.vida-=1;
                hit=true;
            }
     
        }
        
            

    }

    
   
    
    // Update is called once per frame
    void Update()
    {
     pausado=player.pausado;
     if(player.vida<=0){
        particulas.Play();
     }
    }
}
