using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoria2 : MonoBehaviour
{
    public GameObject vict;
    public DatabaseManager databaseManager;
    public player player;

   void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si la colisión entra en el trigger
        if (other.CompareTag("Player"))
        {
            databaseManager.AddScore(player.nombre, player.puntos);
            //Pausa();
            databaseManager.ReadScores();
            
            vict.SetActive(true);
            
        }
    }
    void Start()
    {
      vict.SetActive(false);
    }

    IEnumerator Pausa()
{
    yield return new WaitForSeconds(5);
}
}
