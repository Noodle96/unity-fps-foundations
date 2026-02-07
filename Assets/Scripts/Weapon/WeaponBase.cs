using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Info")]
    [SerializeField] protected Sprite weaponIcon;

    [Header("Ammo")]
    [SerializeField] protected int maxAmmo = 30;
    [SerializeField] protected int currentAmmo;

    [Header("Cooldown")]
    [SerializeField] protected float cooldown = 0.5f;

    protected float lastUseTime = -Mathf.Infinity;

    // ---------- PROPERTIES ----------

    public Sprite Icon => weaponIcon;
    public int Ammo => currentAmmo;

    public float CooldownNormalized
    {
        get
        {
            float elapsed = Time.time - lastUseTime;
            return Mathf.Clamp01(elapsed / cooldown);
        }
    }

    // ---------- LIFECYCLE ----------

    protected virtual void Awake()
    {
        currentAmmo = maxAmmo;
    }

    // ---------- PUBLIC API ----------

    public void TryUse()
    {
        if (!CanUse()) return;

        if (IsContinuous)
        {
            StartUse();
        }
        else
        {
            Use();
            currentAmmo--;
            lastUseTime = Time.time;
        }
    }

    public virtual bool CanUse()
    {
        if (currentAmmo <= 0) return false;
        if (!IsContinuous && Time.time < lastUseTime + cooldown) return false;
        return true;
    }

    // ---------- EXTENSION POINTS ----------

    protected virtual bool IsContinuous => false;

    public void ForceStopUse()
    {
        StopUse();
    }

    protected virtual void StartUse() { }
    protected virtual void StopUse() { }

    protected abstract void Use();

    // ---------- SELECTION ----------

    public virtual void OnSelect()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnDeselect()
    {
        StopUse();
        gameObject.SetActive(false);
    }

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
    }
}
