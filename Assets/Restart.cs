using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    
    public void Reiniciar(){
        SceneManager.LoadScene(1);
    }
    public void MenuInicial(string nombre){
        SceneManager.LoadScene(nombre);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
}
