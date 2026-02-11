using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Info")]
    [SerializeField] protected Sprite weaponIcon;

    [Header("Ammo")]
    [SerializeField] protected int maxAmmo = 30;
    [SerializeField] protected int currentAmmo;

    [Header("Fire Rate")]
    [SerializeField] protected float fireRate = 0.2f; // tiempo entre disparos
    
    public virtual bool IsAutomatic => false;

    protected float nextFireTime;

    // ---------- PROPERTIES ----------
    public Sprite Icon => weaponIcon;
    public int Ammo => currentAmmo;

    public float CooldownNormalized
    {
        get
        {
            float remaining = Mathf.Max(0, nextFireTime - Time.time);
            return 1f - (remaining / fireRate);
        }
    }

    // ---------- LIFECYCLE ----------
    protected virtual void Awake()
    {
        currentAmmo = maxAmmo;
        nextFireTime = 0f;
    }

    // ---------- PUBLIC API ----------
    public bool TryUse()
    {
        if (!CanUse()) return false;

        Use();
        currentAmmo--;
        nextFireTime = Time.time + fireRate;
        return true;
    }

    protected virtual bool CanUse()
    {
        if (currentAmmo <= 0) return false;
        if (Time.time < nextFireTime) return false;
        return true;
    }

    protected abstract void Use();

    // ---------- SELECTION ----------
    public virtual void OnSelect()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnDeselect()
    {
        gameObject.SetActive(false);
    }

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
    }
}
