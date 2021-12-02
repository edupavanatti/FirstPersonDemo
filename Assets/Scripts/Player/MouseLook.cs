using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private const float RotationLimit = 90f;
    private const string MouseXInput = "Mouse X";
    private const string MouseYInput = "Mouse Y";

    [SerializeField] private Transform player;

    private float _mouseSensitivity = 100f;
    private float _cameraXRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var mouseX = Input.GetAxis(MouseXInput) * _mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis(MouseYInput) * _mouseSensitivity * Time.deltaTime;

        _cameraXRotation -= mouseY;
        _cameraXRotation = Mathf.Clamp(_cameraXRotation, -RotationLimit, RotationLimit);

        transform.localRotation = Quaternion.Euler(_cameraXRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
