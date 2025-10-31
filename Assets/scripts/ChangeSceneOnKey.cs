using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnKey : MonoBehaviour
{
    [Header("Configuración de escena")]
    [SerializeField] private string sceneToLoad = "NombreDeTuEscena"; // Nombre de la siguiente escena

    [Header("Configuración del temporizador")]
    [SerializeField] private float tiempoLimite = 20f; // Tiempo máximo antes del cambio automático (en segundos)

    private float timer = 0f;  // Contador interno
    private bool escenaCambiada = false; // Para evitar que se dispare más de una vez

    void Update()
    {
        // Método principal: detección de tecla (puede ser reemplazado por señal OSC)
        if (Input.GetKeyDown(KeyCode.Alpha5) && !escenaCambiada)
        {
            CambiarEscena();
        }
    }

    void FixedUpdate()
    {
        if (escenaCambiada) return; // si ya cambió, no sigue contando

        // Sumar tiempo en cada FixedUpdate
        timer += Time.fixedDeltaTime;

        // Cuando el tiempo alcanza el límite, cambia automáticamente
        if (timer >= tiempoLimite)
        {
            CambiarEscena();
        }
    }

    private void CambiarEscena()
    {
        escenaCambiada = true;
        SceneManager.LoadScene(sceneToLoad);
    }
}


