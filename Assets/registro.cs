using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class registro : MonoBehaviour
{
    public DatabaseManager database;
    public InputField inputField;
    public string usuario;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("iniciado");
    }


    public void UpdateUsername(string newUsername)
    {
        usuario = inputField.text;

    }

    public void Registrar(){

        database.EditUser("1",usuario);
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}