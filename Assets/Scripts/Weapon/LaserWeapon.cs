using UnityEngine;

public class LaserWeapon : WeaponBase
{
    [Header("Laser References")]
    [SerializeField] private LineRenderer laserRenderer;
    [SerializeField] private Transform firePoint;

    [Header("Laser Settings")]
    [SerializeField] private float ammoConsumptionPerSecond = 5f;
    [SerializeField] private float maxDistance = 50f;

    private bool isFiring;

    // Este arma es de uso continuo
    protected override bool IsContinuous => true;

    private void Start()
    {
        laserRenderer.widthMultiplier = 0.02f;
    }

    protected override void StartUse()
    {
        if (isFiring) return;

        isFiring = true;
        laserRenderer.enabled = true;
    }

    protected override void StopUse()
    {
        if (!isFiring) return;

        isFiring = false;
        laserRenderer.enabled = false;
    }

    private void Update()
    {
        if (!isFiring) return;

        HandleAmmoConsumption();
        UpdateLaser();
    }

    private void HandleAmmoConsumption()
    {
        float ammoToConsume = ammoConsumptionPerSecond * Time.deltaTime;
        currentAmmo -= Mathf.CeilToInt(ammoToConsume);

        if (currentAmmo <= 0)
        {
            currentAmmo = 0;
            StopUse();
        }
    }

    private void UpdateLaser()
    {
        laserRenderer.SetPosition(0, firePoint.position);

        Vector3 endPosition = firePoint.position + firePoint.forward * maxDistance;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, maxDistance))
        {
            endPosition = hit.point;
        }

        laserRenderer.SetPosition(1, endPosition);
    }

    // No usamos Use() en armas continuas, pero debemos implementarlo
    protected override void Use() { }
}
