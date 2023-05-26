using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    public int healthToGive;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(collision.name == "Player"){
                collision.GetComponent<player>().vida += healthToGive;
            }else{
                //PlayerController.instance.GameObject.GetComponent<player>().vida+=healthToGive;
            }

            //Destroy(GameObject);
        }
    }
}
