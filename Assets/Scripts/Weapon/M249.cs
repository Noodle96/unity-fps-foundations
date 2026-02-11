using UnityEngine;

public class M249 : ProjectileWeaponBase
{
    // Esta arma es automática
    public override bool IsAutomatic => true;

    protected override void Awake()
    {
        base.Awake();

        // Ajustes típicos M249 (puedes cambiarlos en Inspector)
        fireRate = 0.08f;        // ~750 RPM
        projectileSpeed = 90f;   // balas rápidas
        maxAmmo = 200;
        currentAmmo = maxAmmo;
    }
}
