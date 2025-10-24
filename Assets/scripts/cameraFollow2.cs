using UnityEngine;

public class CameraFollowRock2 : MonoBehaviour
{
    [SerializeField] private Transform rock;            // referencia a la roca
    [SerializeField] private Vector3 offset = new Vector3(0f, 1.5f, -3f); // posición relativa ideal
    [SerializeField] private float smoothSpeed = 5f;    // suavidad del seguimiento
    [SerializeField] private float collisionOffset = 0.3f; // margen para evitar atravesar paredes
    [SerializeField] private LayerMask collisionLayers; // capas que bloquean la cámara

    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (rock == null || cam == null) return;

        // Posición deseada de la cámara (detrás de la roca)
        Vector3 desiredPosition = rock.position + rock.TransformDirection(offset);

        // Verificar si hay colisión entre la roca y la cámara
        Vector3 direction = (desiredPosition - rock.position).normalized;
        float distance = offset.magnitude;

        // Si hay algo entre la roca y la cámara, ajustamos la posición
        if (Physics.Raycast(rock.position, direction, out RaycastHit hit, distance, collisionLayers))
        {
            desiredPosition = hit.point - direction * collisionOffset;
        }

        // Movimiento suave hacia la posición final
        cam.position = Vector3.Lerp(cam.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
