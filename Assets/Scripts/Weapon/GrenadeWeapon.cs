using UnityEngine;
using UnityEngine.InputSystem;

public class GrenadeWeapon : MonoBehaviour
{
    [Header("References")]
    public Transform grenadeSpawnPoint;
    public GameObject grenadePrefab;

    [Header("Throw Settings")]
    public float throwForce = 15f;
    public float upwardForce = 3f;
    public float throwCooldown = 1f;

    private float nextThrowTime;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryThrow();
        }
    }

    void TryThrow()
    {
        if (Time.time < nextThrowTime) return;
        if (GameManager.Instance.grenadeAmmo <= 0) return;

        ThrowGrenade();
    }

    void ThrowGrenade()
    {
        GameManager.Instance.grenadeAmmo--;

        GameObject grenade = Instantiate(
            grenadePrefab,
            grenadeSpawnPoint.position,
            grenadeSpawnPoint.rotation
        );

        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 throwDirection =
                grenadeSpawnPoint.forward * throwForce +
                grenadeSpawnPoint.up * upwardForce;

            rb.AddForce(throwDirection, ForceMode.Impulse);
        }

        nextThrowTime = Time.time + throwCooldown;

        // Actualizar HUD
        GameManager.Instance.UpdateAmmoUI(
            GameManager.Instance.grenadeAmmo,
            GameManager.Instance.grenadeIcon
        );
    }
}
