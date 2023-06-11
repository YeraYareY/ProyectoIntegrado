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

                Destroy(gameObject);
            }
        }
    }

    public void OnButtonClick()
    {
        player.vida+=1;
    }

}
