using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [Header("Config Camera")]
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    private bool firstPersonEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            firstPersonEnabled = !firstPersonEnabled;
            ChangeCamera();
        }
    }

    public void ChangeCamera() {
        if (firstPersonEnabled)
        {
            firstPersonCamera.enabled = true;
            thirdPersonCamera.enabled = false;
        }
        else {
            firstPersonCamera.enabled = false;
            thirdPersonCamera.enabled = true;
        }
    }
}
