using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RockCyclePhysics : MonoBehaviour
{
    [Header("Puntos de movimiento")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [Header("Velocidades y fuerza")]
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private float fallDelay = 1.5f;

    private Rigidbody rb;
    private bool isPushing = false;
    private bool reachedTop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        //rb.constraints = RigidbodyConstraints.FreezeRotation; // evita giros raros
    }

    void Update()
    {
        // Presionar tecla “5” para empujar la roca
        if (Input.GetKey(KeyCode.Alpha5) && !reachedTop)
        {
            isPushing = true;
            rb.useGravity = false; // desactiva gravedad mientras se empuja
            PushRock();
        }
        else
        {
            if (isPushing)
            {
                // al soltar la tecla
                Invoke(nameof(StartFalling), fallDelay);
            }
            isPushing = false;
        }

        // Detectar si llegó al punto máximo
        if (!reachedTop && Vector3.Distance(transform.position, endPoint.position) < 0.3f)
        {
            reachedTop = true;
            Invoke(nameof(StartFalling), fallDelay);
        }
    }

    void PushRock()
    {
        Vector3 direction = (endPoint.position - transform.position).normalized;
        rb.velocity = direction * pushForce;
    }

    void StartFalling()
    {
        rb.useGravity = true;
        reachedTop = false;
    }
}

