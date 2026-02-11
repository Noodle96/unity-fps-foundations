using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 40f;

    [Header("Explosion")]
    [SerializeField] private float explosionRadius = 6f;
    [SerializeField] private float explosionForce = 800f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private LayerMask damageMask;

    [Header("VFX")]
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private MeshRenderer rocketMesh;

    private bool exploded;

    private void Update()
    {
        if (exploded) return;

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (exploded) return;

        exploded = true;
        Explode();
    }

    private void Explode()
    {
        // Spawn visual explosion
        if (explosionVFX != null)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
        }

        // Detect objects in radius
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            explosionRadius,
            damageMask
        );

        foreach (Collider col in hits)
        {
            // Apply physics force
            Rigidbody rb = col.attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(
                    explosionForce,
                    transform.position,
                    explosionRadius
                );
            }

            // Apply damage (if enemy has Health script)


            //Health health = col.GetComponent<Health>();
            //if (health != null)
            //{
            //    health.TakeDamage(damage);
            //}
        }

        if (rocketMesh != null)
            rocketMesh.enabled = false;

        Destroy(gameObject);
    }
}
