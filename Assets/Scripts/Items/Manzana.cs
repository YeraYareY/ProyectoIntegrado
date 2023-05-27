using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    public static int healthToGive=1;
    public player player;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(collision.name == "Player"){
                collision.GetComponent<player>().vida += healthToGive;
                int vidas=collision.GetComponent<player>().vida;
                Debug.Log("Vidas: "+vidas);
                Destroy(gameObject);
            }
        }
    }

    public void OnButtonClick()
    {
         Debug.Log("AAAAAA");
        player.vida+=1;
        Debug.Log("Vidas: "+player.vida);
    }

}
