using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio2 : MonoBehaviour
{

    public player player;
    // Start is called before the first frame update
    void Start()
    {
        int playerPoints = PlayerPrefs.GetInt("PlayerPoints");
        player.puntos=playerPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
