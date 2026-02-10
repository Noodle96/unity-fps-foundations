using UnityEngine;

// Por defecto mantendremos en TPS(Third Person)
public class CameraSwitch : MonoBehaviour
{
    [Header("Config Camera")]
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    private bool firstPersonEnabled = false;

    private void Start()
    {
        ChangeCamera();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T)) {
    //        firstPersonEnabled = !firstPersonEnabled;
    //        ChangeCamera();
    //    }
    //}

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
