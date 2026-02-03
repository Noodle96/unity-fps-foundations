using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("References")]
    public Transform spawnPoint;
    public GameObject bullet;

    [Header("Gun Settings")]
    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        if (Time.time < shotRateTime) return;
        if (GameManager.Instance.gunAmmo <= 0) return;

        Shoot();
    }

    void Shoot()
    {
        GameManager.Instance.gunAmmo--;

        GameObject newBullet = Instantiate(
            bullet,
            spawnPoint.position,
            spawnPoint.rotation
        );

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * shotForce);
        }

        shotRateTime = Time.time + shotRate;

        Destroy(newBullet, 5f);

        // Actualizar HUD
        GameManager.Instance.UpdateAmmoUI(
            GameManager.Instance.gunAmmo,
            GameManager.Instance.gunIcon
        );
    }
    //void Update()
    //{
    //    if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) {
    //        if (Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0) {
    //            GameManager.Instance.gunAmmo--;
    //            GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    //            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
    //            shotRateTime = Time.time + shotRate;
    //            Destroy(newBullet, 5f); // Destroy bullet after 5 seconds
    //        }
    //    }

    //}
}
