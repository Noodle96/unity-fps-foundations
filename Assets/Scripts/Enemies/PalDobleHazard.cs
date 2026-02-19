using UnityEngine;

public class PalDobleHazard : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damageAmount = 20;


    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 180f; // grados por segundo
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // eje Y por defecto

    private void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    // Con mi player Character Controller no funciona el onCollisionEnter
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("onCollisionEnter");
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("[OnCollisionEnter] Colision con doble paleta");
    //        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("[OntriggerEnter] Jugador golpeado por pal doble");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
