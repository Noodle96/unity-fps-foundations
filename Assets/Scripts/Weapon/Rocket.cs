using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Explosion")]
    [SerializeField] private float explosionRadius = 6f;
    [SerializeField] private float explosionForce = 800f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private LayerMask hitMask;

    private bool exploded;

    private void OnCollisionEnter(Collision collision)
    {
        if (exploded) return;
        exploded = true;

        Explode();
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            explosionRadius,
            hitMask
        );

        foreach (Collider col in hits)
        {
            // Fuerza física
            Rigidbody rb = col.attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(
                    explosionForce,
                    transform.position,
                    explosionRadius
                );
            }

            // Daño (si luego tienes Health)
            // col.GetComponent<Health>()?.TakeDamage(damage);
        }

        // Aquí puedes instanciar FX de explosión

        Destroy(gameObject);
    }
}
