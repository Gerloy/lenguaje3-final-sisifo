using UnityEngine;

public class GyroLook : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    [SerializeField] private float mouseSensitivity = 100f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        // Intentar activar el giroscopio
        gyroEnabled = SystemInfo.supportsGyroscope;

        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }

        // Bloquear cursor en modo PC
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (gyroEnabled && Application.isMobilePlatform)
        {
            // Rotación por giroscopio
            transform.localRotation = GyroToUnity(gyro.attitude);
        }
        else
        {
            // Control por mouse (modo PC)
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            rotationY += mouseX;

            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        // Convierte el sistema de coordenadas del giroscopio a Unity
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}

