using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Enemy : MonoBehaviour
{
    public static bool hit;
    public bool pausado;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            Debug.Log(pausado);
            if(!pausado){
                hit=true;
            }
     
        }
        
            

    }

    
   
    
    // Update is called once per frame
    void Update()
    {
     pausado=player.pausado;
    }
}
