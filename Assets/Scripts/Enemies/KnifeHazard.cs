using Unity.Hierarchy;
using UnityEngine;

public class KnifeHazard : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("onCollisionEnter");
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador golpeado por cuchillo");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
