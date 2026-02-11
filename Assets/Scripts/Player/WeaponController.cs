using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Transform weaponsPanel;
    [SerializeField] private WeaponSlotUI weaponSlotPrefab;

    //private List<WeaponSlotUI> weaponSlots = new List<WeaponSlotUI>();
    private List<WeaponSlotUI> weaponSlots = new();



    [Header("Weapons")]
    //[SerializeField] private List<WeaponBase> weapons = new List<WeaponBase>();
    [SerializeField] private List<WeaponBase> weapons = new();

    private int currentWeaponIndex = 0;
    public WeaponBase CurrentWeapon => weapons[currentWeaponIndex];

    private void Start()
    {
        // Desactivar todas las armas
        foreach (var weapon in weapons)
        {
            weapon.OnDeselect();
        }
        CreateWeaponSlots();
        // Activar la primera
        if (weapons.Count > 0)
        {
            currentWeaponIndex = 0;
            weapons[0].OnSelect();
            weaponSlots[0].SetActive(true);
        }
    }

    private void Update()
    {
        HandleWeaponUse();
        HandleWeaponSwitch();
    }

    // ---------- INPUT: USO DEL ARMA ----------

    private void HandleWeaponUse()
    {
        if (Mouse.current == null && CurrentWeapon == null) return;

        if (CurrentWeapon.IsAutomatic)
        {
            // Automáticas: mantener presionado
            if (Mouse.current.leftButton.isPressed)
            {
                CurrentWeapon.TryUse();
            }
        }
        else
        {
            // Semi / single-shot
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                CurrentWeapon.TryUse();
            }
        }
    }

    // ---------- INPUT: CAMBIO DE ARMA ----------

    private void HandleWeaponSwitch()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            SwitchToNextWeapon();
        }
    }

    private void SwitchToNextWeapon()
    {
        weapons[currentWeaponIndex].OnDeselect();
        weaponSlots[currentWeaponIndex].SetActive(false);

        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;

        weapons[currentWeaponIndex].OnSelect();
        weaponSlots[currentWeaponIndex].SetActive(true);
    }


    private void CreateWeaponSlots()
    {
        weaponSlots.Clear();

        foreach (var weapon in weapons)
        {
            WeaponSlotUI slot = Instantiate(
                weaponSlotPrefab,
                weaponsPanel
            );

            slot.Bind(weapon);
            slot.SetActive(false);

            weaponSlots.Add(slot);
        }
    }
}
