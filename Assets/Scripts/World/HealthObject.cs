using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int health = 25;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject pickupEffectPrefab;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
