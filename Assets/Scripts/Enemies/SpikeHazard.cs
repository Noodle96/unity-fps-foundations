using UnityEngine;

public class SpikeHazard : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float damageCooldown = 1f;

    [Header("Movement")]
    [SerializeField] private float floatHeight = 0.3f;
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float direccion = 1f;


    //[Header("Audio")]
    //[SerializeField] private AudioClip hitSound;

    private Vector3 startPosition;
    private float lastDamageTime;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        FloatMotion();
        RotateMotion();
    }

    private void FloatMotion()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void RotateMotion()
    {
        transform.Rotate(direccion * Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(" OnTriggerStay con: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("OnTriggerStay with Player");
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

                //if (hitSound != null)
                //    AudioSource.PlayClipAtPoint(hitSound, transform.position);

                lastDamageTime = Time.time;
            }
        }
        // las balas del player
        if (other.gameObject.CompareTag("PlayerBullet")) { 
            //Destruimos la espina esferica
            Destroy(gameObject);

            //Destruimos la bala
            Destroy(other.gameObject);
        }

    }

}
