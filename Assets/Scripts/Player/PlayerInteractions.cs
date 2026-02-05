using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform startPlayerPosition;
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
