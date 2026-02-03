using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject gun;
    public GameObject grenade;

    public enum WeaponType
    {
        Gun,
        Grenade
    }

    public WeaponType currentWeapon;

    private void Start()
    {
        EquipGun();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipGrenade();
        }
    }

    void EquipGun()
    {
        gun.SetActive(true);
        grenade.SetActive(false);
        currentWeapon = WeaponType.Gun;
        GameManager.Instance.UpdateAmmoUI(
            GameManager.Instance.gunAmmo,
            GameManager.Instance.gunIcon
        );
    }

    void EquipGrenade()
    {
        gun.SetActive(false);
        grenade.SetActive(true);
        currentWeapon = WeaponType.Grenade;
        GameManager.Instance.UpdateAmmoUI(
            GameManager.Instance.grenadeAmmo,
            GameManager.Instance.grenadeIcon
        );
    }
}
