using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("References")]
    public Transform spawnPoint;
    public GameObject bullet;
    public CooldownUI cooldownUI;

    [Header("Gun Settings")]
    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0f;
    private float cooldownTimer;

    [Header("Sound")]
    private AudioSource audioSource;
    public AudioClip shootSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cooldownTimer = shotRate; // Inicializamos el timer de cooldown al máximo
        cooldownUI.SetCooldown(1f); // actualizamos la UI a lleno
    }
    void Update()
    {
        UpdateCooldownUI();

        if (Mouse.current == null) return;

        if (Mouse.current?.leftButton.wasPressedThisFrame == true)
        {
            TryShoot();
        }
    }

    void UpdateCooldownUI()
    {
        if (cooldownTimer < shotRate)
        {
            cooldownTimer += Time.deltaTime;
            float normalized = cooldownTimer / shotRate;
            cooldownUI.SetCooldown(normalized);
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
        // Reproducir sonido de disparo
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

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
        cooldownTimer = 0f; // reiniciamos el timer de cooldown
        cooldownUI.SetCooldown(0f); // actualizamos la UI a 0

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
