using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    public AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        sonido.loop=true;
        sonido.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
