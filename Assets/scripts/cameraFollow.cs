using UnityEngine;

public class CameraFollowRock : MonoBehaviour
{
    [SerializeField] private Transform rock;          // referencia a la roca
    [SerializeField] private Vector3 offset = new Vector3(0f, 1.5f, -2f); // posición relativa a la roca
    [SerializeField] private float smoothSpeed = 5f;  // velocidad de seguimiento suave

    private Transform cam;  // referencia interna a la cámara (si está en VR o MouseLook)

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (rock == null || cam == null) return;

        // Calcular posición objetivo: la cámara sigue la roca con un offset fijo
        Vector3 targetPosition = rock.position + rock.TransformDirection(offset);

        // Suavizar el movimiento
        cam.position = Vector3.Lerp(cam.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}

