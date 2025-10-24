using UnityEngine;

public class RockCycle : MonoBehaviour
{
    [Header("Puntos de movimiento")]
    [SerializeField] private Transform startPoint;   // punto inicial (abajo de la montaña)
    [SerializeField] private Transform endPoint;     // punto final (cerca de la cima)

    [Header("Velocidades")]
    [SerializeField] private float pushSpeed = 2f;   // velocidad de ascenso
    [SerializeField] private float fallSpeed = 4f;   // velocidad de retroceso

    private bool isPushing = false;
    private bool reachedTop = false;

    void Update()
    {
        // Mientras la tecla 5 esté presionada
        if (Input.GetKey(KeyCode.Alpha5) && !reachedTop)
        {
            isPushing = true;
            MoveRockUp();
        }
        else
        {
            isPushing = false;

            // Si se soltó la tecla o llegó a la cima, empieza a caer
            if (!isPushing || reachedTop)
                MoveRockDown();
        }

        // Si la roca llegó al punto máximo
        if (Vector3.Distance(transform.position, endPoint.position) < 0.05f && !reachedTop)
        {
            reachedTop = true;
            Invoke(nameof(ResetCycle), 1.5f); // espera un momento antes de caer
        }
    }

    void MoveRockUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, pushSpeed * Time.deltaTime);
    }

    void MoveRockDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPoint.position, fallSpeed * Time.deltaTime);
    }

    void ResetCycle()
    {
        reachedTop = false;
    }
}

