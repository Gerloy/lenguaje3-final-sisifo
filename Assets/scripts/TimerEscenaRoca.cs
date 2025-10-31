using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerEscenaRoca : MonoBehaviour
{
     [SerializeField] private string sceneToLoad2 = "NombreDeTuEscena"; // Nombre de la siguiente escena

    [Header("Configuración del temporizador")]
    [SerializeField] private float tiempoLimite2 = 20f; // Tiempo máximo antes del cambio automático (en segundos)

    private float timer2 = 0f;
    private bool escenaCambiada2 = false;
    // Start is called before the first frame update
    void Update()
    {
        // Método principal: detección de tecla (puede ser reemplazado por señal OSC)
        if (timer2 >= tiempoLimite2 && !escenaCambiada2)
        {
            CambiarEscena2();
        }
    }

    void FixedUpdate()
    {
        if (escenaCambiada2) return; // si ya cambió, no sigue contando

        // Sumar tiempo en cada FixedUpdate
        timer2 += Time.fixedDeltaTime;

        // Cuando el tiempo alcanza el límite, cambia automáticamente
        if (timer2 >= tiempoLimite2)
        {
            CambiarEscena2();
        }
    }

    private void CambiarEscena2()
    {
        escenaCambiada2 = true;
        SceneManager.LoadScene(sceneToLoad2);
    }
}
