using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnKey : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "NombreDeTuEscena"; // Asigna el nombre exacto de la escena

    void Update()
    {
        // Detecta si se presiona la tecla '5'
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

