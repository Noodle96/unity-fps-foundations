//using UnityEngine;
//using UnityEngine.InputSystem;

//public class Gun : MonoBehaviour
//{
//    [Header("References")]
//    public Transform spawnPoint;
//    public GameObject bullet;
//    public CooldownUI cooldownUI;

//    [Header("Gun Settings")]
//    public float shotForce = 1500f;
//    public float shotRate = 0.5f;

//    private float shotRateTime = 0f;
//    private float cooldownTimer;

//    [Header("Sound")]
//    private AudioSource audioSource;
//    public AudioClip shootSound;

//    private void Start()
//    {
//        audioSource = GetComponent<AudioSource>();
//        cooldownTimer = shotRate; // Inicializamos el timer de cooldown al máximo
//        cooldownUI.SetCooldown(1f); // actualizamos la UI a lleno
//    }
//    void Update()
//    {
//        UpdateCooldownUI();

//        if (Mouse.current == null) return;

//        if (Mouse.current?.leftButton.wasPressedThisFrame == true)
//        {
//            TryShoot();
//        }
//    }

//    void UpdateCooldownUI()
//    {
//        if (cooldownTimer < shotRate)
//        {
//            cooldownTimer += Time.deltaTime;
//            float normalized = cooldownTimer / shotRate;
//            cooldownUI.SetCooldown(normalized);
//        }
//    }

//    void TryShoot()
//    {
//        if (Time.time < shotRateTime) return;
//        if (GameManager.Instance.gunAmmo <= 0) return;

//        Shoot();
//    }

//    void Shoot()
//    {
//        GameManager.Instance.gunAmmo--;
//        // Reproducir sonido de disparo
//        if (audioSource != null && shootSound != null)
//        {
//            audioSource.PlayOneShot(shootSound);
//        }

//        GameObject newBullet = Instantiate(
//            bullet,
//            spawnPoint.position,
//            spawnPoint.rotation
//        );

//        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
//        if (rb != null)
//        {
//            rb.AddForce(spawnPoint.forward * shotForce);
//        }

//        shotRateTime = Time.time + shotRate;
//        cooldownTimer = 0f; // reiniciamos el timer de cooldown
//        cooldownUI.SetCooldown(0f); // actualizamos la UI a 0

//        Destroy(newBullet, 5f);

//        // Actualizar HUD
//        GameManager.Instance.UpdateAmmoUI(
//            GameManager.Instance.gunAmmo,
//            GameManager.Instance.gunIcon
//        );
//    }
//}



using UnityEngine;

public class Gun : WeaponBase
{
    [Header("Gun References")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Gun Settings")]
    [SerializeField] private float shotForce = 1500f;

    [Header("Sound")]
    [SerializeField] private AudioClip shootSound;

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake(); // Inicializa munición desde WeaponBase
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Implementación específica del disparo
    /// </summary>
    protected override void Use()
    {
        // Sonido
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Crear bala
        GameObject newBullet = Instantiate(
            bulletPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        // Aplicar fuerza
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * shotForce);
        }

        Destroy(newBullet, 5f);
    }
}
