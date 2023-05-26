using Firebase;
using Firebase.Database;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    DatabaseReference databaseReference;

    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void WriteScore(string userId, int score)
    {
        DatabaseReference scoreRef = databaseReference.Child("scores").Child(userId);
        scoreRef.SetValueAsync(score);
    }


void Update(){
    //AddScore(1, 100);
}
    // Otros métodos para leer, actualizar y eliminar puntuaciones...

    // Ejemplo de lectura de puntuaciones:
    void ReadScores()
    {
        FirebaseDatabase.DefaultInstance.GetReference("scores").GetValueAsync()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // Manejo de errores...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    // Procesar los datos de puntuación...
                }
            });
    }

     // Método para agregar una puntuación
    public void AddScore(int userId, int score)
    {
        // Crea una referencia a la colección "puntuación" y genera un nuevo ID para el registro
        DatabaseReference scoreRef = databaseReference.Child("puntuacion").Push();
        
        // Establece el valor de la puntuación en la referencia generada
        scoreRef.SetValueAsync(score);

        Debug.Log("Puntuación agregada: " + score);
    }
}