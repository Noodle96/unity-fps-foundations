using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private Image weaponIcon;
    [SerializeField] private Slider cooldownSlider;

    private WeaponBase weapon;

    /// <summary>
    /// Vincula este slot con un arma concreta
    /// </summary>
    public void Bind(WeaponBase weaponBase)
    {
        weapon = weaponBase;

        weaponIcon.sprite = weapon.Icon;
        ammoText.text = weapon.Ammo.ToString();

        cooldownSlider.gameObject.SetActive(false);
    }

    /// <summary>
    /// Llamado cuando el arma está activa
    /// </summary>
    public void SetActive(bool active)
    {
        cooldownSlider.gameObject.SetActive(active);

        // Visual simple: activo vs inactivo
        float alpha = active ? 1f : 0.4f;
        weaponIcon.color = new Color(1f, 1f, 1f, alpha);
        ammoText.alpha = alpha;
    }

    private void Update()
    {
        if (weapon == null) return;

        ammoText.text = weapon.Ammo.ToString();

        if (cooldownSlider.gameObject.activeSelf)
        {
            cooldownSlider.value = weapon.CooldownNormalized;
        }
    }
}
