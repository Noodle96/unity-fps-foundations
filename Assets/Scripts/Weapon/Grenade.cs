using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    private float countdown;
    public float radius = 5f;
    public float explosionForce = 70f;
    bool exploted = false;
    public GameObject explosionEffect;

    private void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !exploted) {
            Explote();
            exploted = true;
        }
    }

    private void Explote() {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var coll in colliders) {
            Rigidbody rb = coll.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce *  10 , transform.position, radius);
            }
        }
        Destroy(gameObject);
    }


}
