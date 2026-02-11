using UnityEngine;

public abstract class ProjectileWeaponBase : WeaponBase
{
    [Header("Projectile")]
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float projectileSpeed = 50f;

    [Header("Aim")]
    [SerializeField] protected CrosshairRaycast crosshairSystem;

    [Header("Sound")]
    [SerializeField] protected AudioClip shootSound;

    protected AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Use()
    {
        PlaySound();
        FireProjectile();
    }

    protected virtual void FireProjectile()
    {
        // 1. Punto c�mara
        Vector3 cameraAimPoint = crosshairSystem.AimWorldPoint;

        // 2. Direcci�n desde arma
        Vector3 dirFromGun = (cameraAimPoint - spawnPoint.position).normalized;

        // 3. Segundo raycast
        Vector3 finalAimPoint = cameraAimPoint;

        if (Physics.Raycast(
            spawnPoint.position,
            dirFromGun,
            out RaycastHit hit,
            300f,
            ~0,
            QueryTriggerInteraction.Ignore
        ))
        {
            finalAimPoint = hit.point;
        }

        Vector3 finalDir = (finalAimPoint - spawnPoint.position).normalized;

        // 4. Instanciar proyectil
        GameObject proj = Instantiate(
            projectilePrefab,
            spawnPoint.position,
            Quaternion.LookRotation(finalDir)
        );

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = finalDir * projectileSpeed;
        }
    }

    protected void PlaySound()
    {
        if (audioSource != null && shootSound != null)
            audioSource.PlayOneShot(shootSound);
    }
}
