using Firebase;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour
{
    DatabaseReference databaseReference;
    public Text scoreText;

    public void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        ReadScores();
    }

void Update(){
    ReadScores();
    }

    public void ReadScores()
    {
        FirebaseDatabase.DefaultInstance.GetReference("puntuacion").OrderByValue().LimitToLast(3).OrderByValue().LimitToFirst(3).GetValueAsync()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("Fallo");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                // Procesar los datos de puntuación
                string scoreString = "";
                List<DataSnapshot> snapshotList = new List<DataSnapshot>();
                foreach (var childSnapshot in snapshot.Children)
                {
                    snapshotList.Add(childSnapshot);
                }
                snapshotList.Reverse();
                foreach (var childSnapshot in snapshotList)
                {
                    string user = childSnapshot.Key;
                    int score = int.Parse(childSnapshot.Value.ToString());
                    Debug.Log("Score: " + score);
                    // Concatenar las puntuaciones en un string
                        scoreString += "Usuario: " + user + " - Puntuación: " + score + "\n";
                    }
                    // Asignar el string de puntuaciones al objeto Text
                    scoreText.text = scoreString;
                }
            });
    }




     // Método para agregar una puntuación
    public void AddScore(string user, int score)
    {

        DatabaseReference scoreRef = databaseReference.Child("puntuacion").Child(user);
        scoreRef.SetValueAsync(score);
        ReadScores();
        Debug.Log("Puntuación agregada: " + score);
    }
    
   


    public void EditUser(string userId, string newName)
    {
        DatabaseReference userRef = databaseReference.Child("usuarios").Child(userId);
        userRef.SetValueAsync(newName);

        Debug.Log("Nombre de usuario editado para el ID: " + userId);
    }

    public void borrarPuntuaciones(){
        DatabaseReference puntuacionRef = databaseReference.Child("puntuacion");
        puntuacionRef.RemoveValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
            Debug.Log("Fallo");
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Puntuaciones borradas correctamente.");
            }
        });
    }
}