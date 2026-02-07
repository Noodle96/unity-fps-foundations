using UnityEngine;

public class M4_8 : WeaponBase
{
    [Header("M4_8 References")]
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
