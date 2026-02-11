using UnityEngine;

public class ThirdPersonLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerBody;   // Player root
    [SerializeField] private Transform cameraPivot;  // parentSecondCamera

    [Header("Settings")]
    [SerializeField] private float mouseSensitivity = 120f;
    [SerializeField] private float minPitch = -35f;
    [SerializeField] private float maxPitch = 45f;

    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación horizontal -> player
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotación vertical -> pivot
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
