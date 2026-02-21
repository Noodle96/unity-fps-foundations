using UnityEngine;

public class TrapMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Vector3 localTargetOffset = new Vector3(0, 0, 2f);
    [SerializeField] private float speed = 5f;
    [SerializeField] private float waitTime = 0.3f;
    [SerializeField] private int damageAmount = 20;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip impactSound;


    private Vector3 startLocalPosition;
    private Vector3 targetLocalPosition;

    private bool movingForward = true;
    private float waitTimer = 0f;

    private void Start()
    {
        startLocalPosition = transform.localPosition;
        targetLocalPosition = startLocalPosition + localTargetOffset;
    }

    private void Update()
    {
        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        if (movingForward)
        {
            MoveTo(targetLocalPosition);

            if (Vector3.Distance(transform.localPosition, targetLocalPosition) < 0.05f)
            {
                if (impactSound != null)
                    audioSource.PlayOneShot(impactSound);
                movingForward = false;
                waitTimer = waitTime;
            }
        }
        else
        {
            MoveTo(startLocalPosition);

            if (Vector3.Distance(transform.localPosition, startLocalPosition) < 0.05f)
            {
                movingForward = true;
                waitTimer = waitTime;
            }
        }
    }

    private void MoveTo(Vector3 destination)
    {
        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            destination,
            speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador golpeo los cubos");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
