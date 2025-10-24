using UnityEngine;

public class CameraFollowRockStable : MonoBehaviour
{
    [SerializeField] private Transform rock;
    [SerializeField] private Vector3 offset = new Vector3(0f, 1.5f, -3f);
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float collisionOffset = 0.3f;
    [SerializeField] private LayerMask collisionLayers;

    private Transform cam;
    private Vector3 currentVelocity = Vector3.zero; // para suavizar el movimiento
    private Vector3 desiredPosition;
    private Vector3 lastRockPosition;

    void Start()
    {
        cam = Camera.main.transform;
        if (rock != null)
            lastRockPosition = rock.position;
    }

    void FixedUpdate()
    {
        // Guardamos la posición estable de la roca (última del frame físico)
        if (rock != null)
            lastRockPosition = rock.position;
    }

    void LateUpdate()
    {
        if (rock == null || cam == null) return;

        // Calculamos la posición deseada sin depender de la rotación local de la roca
        Vector3 baseOffset = offset; // ignora la rotación física, usa un offset global fijo

        desiredPosition = lastRockPosition + baseOffset;

        // Raycast para evitar que la cámara atraviese la montaña
        Vector3 direction = (desiredPosition - lastRockPosition).normalized;
        float distance = offset.magnitude;

        if (Physics.Raycast(lastRockPosition, direction, out RaycastHit hit, distance, collisionLayers))
        {
            Vector3 hitAdjusted = hit.point - direction * collisionOffset;
            desiredPosition = Vector3.Lerp(desiredPosition, hitAdjusted, Time.deltaTime * 8f); // amortigua la corrección
        }

        // Suavizamos el movimiento general (sin saltos)
        cam.position = Vector3.SmoothDamp(cam.position, desiredPosition, ref currentVelocity, 1f / smoothSpeed);
    }
}

