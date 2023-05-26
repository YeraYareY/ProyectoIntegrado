using Firebase;
using Firebase.Database;
using UnityEngine;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                // Configurar la instancia de Firebase con las credenciales
                // y otros detalles necesarios.
                DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                Debug.Log("Firebase inicializado correctamente");
            }
            else
            {
                Debug.LogError("No se pudo resolver todas las dependencias de Firebase: " + dependencyStatus);
            }
        });
    }
}