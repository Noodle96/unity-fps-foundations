using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    private float countdown;
    public float radius = 5f;
    public float explosionForce = 70f;
    bool exploted = false;
    public GameObject explosionEffect;

    [Header("Sounds")]
    private AudioSource audioSource;
    public AudioClip explosionSound;

    private void Start()
    {
        countdown = delay;
        audioSource = GetComponent<AudioSource>();
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

        // Reproducir sonido de explosión
        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
            //AudioSource.PlayClipAtPoint(
            //    explosionSound,
            //    transform.position
            //);
        }
        // Desactivar el objeto después de la explosión
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        Destroy(gameObject, delay * 2f);
    }


}
