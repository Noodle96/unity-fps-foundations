using UnityEngine;

public class RPG7 : ProjectileWeaponBase
{
    public override bool IsAutomatic => false;

    protected override void Awake()
    {
        base.Awake();

        fireRate = 1.2f;        // tiempo entre disparos
        projectileSpeed = 35f;  // cohete lento
        maxAmmo = 30;
        currentAmmo = maxAmmo;
    }
}
