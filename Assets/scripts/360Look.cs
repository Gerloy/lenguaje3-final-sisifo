using UnityEngine;

public class MouseLook360 : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Actualizar rotaciones acumuladas
        rotationY += mouseX;         // horizontal (eje Y del mundo)
        rotationX -= mouseY;         // vertical (eje X local)
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // limitar rotación vertical

        // Aplicar la rotación combinada
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}



