using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player")) {
            // Cuando el BulletEnemy choca con el Player, esta desaparece.
            Destroy(gameObject);
        }
    }
}
