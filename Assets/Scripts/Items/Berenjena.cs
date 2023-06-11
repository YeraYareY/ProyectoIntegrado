using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berenjena : MonoBehaviour
{
    public static float speedBoost=10f;
    public player player;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(collision.name == "Player"){
                collision.GetComponent<player>().velocidadMovimiento += speedBoost;
                float speed=collision.GetComponent<player>().velocidadMovimiento;
                Destroy(gameObject);
            }
        }
    }

    public void OnButtonClick()
    {
        player.velocidadMovimiento+=10f;
    }

}
