using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Enemy : MonoBehaviour
{
    public static bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            hit=true;
            Debug.Log(hit);
            
            if(hit){
                if (hit)
                {
                    StartCoroutine(Pausar());
                }
                
                Debug.Log(hit);
                

            }
        }
        
            

    }
    IEnumerator Pausar()
    {
        Debug.Log("Pausando...");
        yield return new WaitForSeconds(2);
        Debug.Log("La pausa ha terminado.");
        hit=player.golpeado;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
