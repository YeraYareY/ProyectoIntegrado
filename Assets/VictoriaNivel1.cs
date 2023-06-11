using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoriaNivel1 : MonoBehaviour
{

    public player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            int puntos= player.puntos;
            PlayerPrefs.SetInt("PlayerPoints", puntos);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
