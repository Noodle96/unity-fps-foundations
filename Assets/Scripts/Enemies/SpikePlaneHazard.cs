using UnityEngine;

public class SpikePlaneHazard : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float damageCooldown = 1f;


    [Header("Movement Settings")]
    [SerializeField] private float minY = -0.5f;
    [SerializeField] private float maxY = 0f;
    [SerializeField] private float speed = 1f;

    [Header("Start Direction")]
    [SerializeField] private bool startFromTop = true;

    private float startTime;
    private float initialY;
    private float phaseOffset;
    private float lastDamageTime;

    private void Start()
    {
        initialY = transform.localPosition.y;

        // Si queremos que empiece desde abajo,
        // desplazamos el tiempo medio ciclo
        if (startFromTop)
            phaseOffset = 0f;
        else
            phaseOffset = (maxY - minY) / speed;

        startTime = Time.time + phaseOffset;
    }

    private void Update()
    {
        float offset = Mathf.PingPong((Time.time - startTime) * speed, maxY - minY) + minY;

        Vector3 localPos = transform.localPosition;
        localPos.y = initialY + offset;

        transform.localPosition = localPos;
    }

    private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Player")){
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
                //PlayerHealth ph = other.GetComponent<PlayerHealth>();
                //if (ph != null)
                //{
                //    ph.TakeDamage(damageAmount);
                //    lastDamageTime = Time.time;
                //}
                lastDamageTime = Time.time;
            }
        }
    }
}
