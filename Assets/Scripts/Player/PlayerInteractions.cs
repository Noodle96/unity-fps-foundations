using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform startPlayerPosition;
    private WeaponController weaponController;

    private void Start()
    {
        weaponController = GetComponent<WeaponController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo")) {
            AmmoBox ammoBox = other.GetComponent<AmmoBox>();
            if (ammoBox != null && weaponController != null)
            {
                weaponController.CurrentWeapon.AddAmmo(ammoBox.ammoAmount);
            }

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("HealthObject")) {
            int h = other.gameObject.GetComponent<HealthObject>().health;
            GameManager.Instance.AddHealth(h);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("DeathFloor")) {
            GameManager.Instance.LoseHealth(50);
            GetComponent<CharacterController>().enabled = false;
            transform.position = startPlayerPosition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")) {
            // Cuando un EnemyBullet choca con el Player, este pierde vida en X puntos
            GameManager.Instance.LoseHealth(10);
        }
    }
}
