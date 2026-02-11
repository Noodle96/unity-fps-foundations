//using UnityEngine;
//using UnityEngine.InputSystem;

//public class GrenadeWeapon : MonoBehaviour
//{
//    [Header("References")]
//    public Transform grenadeSpawnPoint;
//    public GameObject grenadePrefab;
//    public CooldownUI cooldownUI;

//    [Header("Throw Settings")]
//    public float throwForce = 15f;
//    public float upwardForce = 3f;
//    public float throwCooldown = 2f;

//    private float nextThrowTime;
//    private float cooldownTimer;


//    void Update()
//    {
//        UpdateCooldownUI();
//        if (Mouse.current == null) return;

//        if (Mouse.current.leftButton.wasPressedThisFrame)
//        {
//            TryThrow();
//        }
//    }
//    void UpdateCooldownUI()
//    {
//        if (cooldownTimer < throwCooldown)
//        {
//            cooldownTimer += Time.deltaTime;
//            float normalized = cooldownTimer / throwCooldown;
//            cooldownUI.SetCooldown(normalized);
//        }
//    }
//    void TryThrow()
//    {
//        if (Time.time < nextThrowTime) return;
//        if (GameManager.Instance.grenadeAmmo <= 0) return;

//        ThrowGrenade();
//    }

//    void ThrowGrenade()
//    {
//        GameManager.Instance.grenadeAmmo--;

//        GameObject grenade = Instantiate(
//            grenadePrefab,
//            grenadeSpawnPoint.position,
//            grenadeSpawnPoint.rotation
//        );

//        Rigidbody rb = grenade.GetComponent<Rigidbody>();
//        if (rb != null)
//        {
//            Vector3 throwDirection =
//                grenadeSpawnPoint.forward * throwForce +
//                grenadeSpawnPoint.up * upwardForce;

//            rb.AddForce(throwDirection, ForceMode.Impulse);
//        }

//        nextThrowTime = Time.time + throwCooldown;
//        cooldownTimer = 0f;
//        cooldownUI.SetCooldown(0f);

//        // Actualizar HUD
//        GameManager.Instance.UpdateAmmoUI(
//            GameManager.Instance.grenadeAmmo,
//            GameManager.Instance.grenadeIcon
//        );
//    }
//}


//using UnityEngine;

//public class GrenadeWeapon : WeaponBase
//{
//    [Header("Grenade References")]
//    [SerializeField] private Transform grenadeSpawnPoint;
//    [SerializeField] private GameObject grenadePrefab;

//    [Header("Throw Settings")]
//    [SerializeField] private float throwForce = 15f;
//    [SerializeField] private float upwardForce = 3f;

//    protected override void Use()
//    {
//        GameObject grenade = Instantiate(
//            grenadePrefab,
//            grenadeSpawnPoint.position,
//            grenadeSpawnPoint.rotation
//        );

//        Rigidbody rb = grenade.GetComponent<Rigidbody>();
//        if (rb != null)
//        {
//            Vector3 throwDirection =
//                grenadeSpawnPoint.forward * throwForce +
//                grenadeSpawnPoint.up * upwardForce;

//            rb.AddForce(throwDirection, ForceMode.Impulse);
//        }
//    }
//}


using UnityEngine;

public class GrenadeWeapon : ThrowableWeaponBase
{
    //[Header("Animation")]
    //[SerializeField] private Animator playerAnimator;
    //[SerializeField] private string throwTriggerName = "ThrowGrenade";

    //public override bool IsAutomatic => false;

    //protected override void Use()
    //{
    //    // NO lanzar todavía
    //    playerAnimator.SetTrigger(throwTriggerName);
    //}

    //// Este método será llamado desde la animación
    //public void SpawnGrenade()
    //{
    //    base.Use(); // ahora sí ejecuta Throw()
    //}
}
