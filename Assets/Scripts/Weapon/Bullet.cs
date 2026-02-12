using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            // Destruimos al enemy
            Destroy(collision.gameObject);

            // Destruimos la bala
            Destroy(gameObject);
        }
    }
}
