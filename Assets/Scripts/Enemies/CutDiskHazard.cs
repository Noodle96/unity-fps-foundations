using UnityEngine;

public class CutDiskHazard : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveDistance = 3f;   // Distancia máxima en Z
    [SerializeField] private float moveSpeed = 2f;      // Velocidad de movimiento
    [SerializeField] private int damageAmount = 20;     // Daño del disco


    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 200f; // Velocidad base de rotación

    private Vector3 startPosition;
    private float previousZ;

    private void Start()
    {
        startPosition = transform.localPosition;
        previousZ = startPosition.z;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    //private void Move()
    //{
    //    // Movimiento en eje Z
    //    transform.localPosition += Vector3.forward * moveDirection * moveSpeed * Time.deltaTime;

    //    // Cambiar dirección cuando llegue al límite
    //    if (Mathf.Abs(transform.localPosition.z - startPosition.z) >= moveDistance)
    //    {
    //        moveDirection *= -1;
    //    }
    //}
    private void Move()
    {
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;

        Vector3 newPos = startPosition + Vector3.forward * offset;
        transform.localPosition = newPos;
    }

    //private void Rotate()
    //{
    //    // Rotación depende de dirección del movimiento
    //    transform.Rotate(Vector3.right * moveDirection * rotationSpeed * Time.deltaTime);
    //}
    private void Rotate()
    {
        float currentZ = transform.localPosition.z;
        float direction = Mathf.Sign(currentZ - previousZ);

        transform.Rotate(Vector3.right * direction * rotationSpeed * Time.deltaTime);

        previousZ = currentZ;
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
