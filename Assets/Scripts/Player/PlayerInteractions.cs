using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo")) { 
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammoAmount;
            // Actualizar HUD
            GameManager.Instance.UpdateAmmoUI(
                GameManager.Instance.gunAmmo,
                GameManager.Instance.gunIcon
            );
            Destroy(other.gameObject);
        }
    }
}
