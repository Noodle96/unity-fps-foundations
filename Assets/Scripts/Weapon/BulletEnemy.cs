using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            // Cuando el BulletEnemy choca con el Player, esta desaparece.
            Destroy(gameObject);
        }
    }
}
