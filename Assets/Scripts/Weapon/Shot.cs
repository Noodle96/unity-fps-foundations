using UnityEngine;
using UnityEngine.InputSystem;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0f;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) { 
            GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
