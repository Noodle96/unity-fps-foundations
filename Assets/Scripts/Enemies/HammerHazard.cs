using UnityEngine;

public class HammerHazard : MonoBehaviour
{
    [Header("Swing Settings")]
    public float maxAngle = 90f;
    public float speed = 2f;

    [Tooltip("Desfase inicial en grados (0 = centro, 90 = extremo)")]
    public float startPhase = 0f;

    private Quaternion initialRotation;
    private float phaseOffset;

    [Header("Audio")]
    private AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        initialRotation = transform.rotation;
        audioSource = GetComponent<AudioSource>();

        // Convertimos grados a radianes
        phaseOffset = startPhase * Mathf.Deg2Rad;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed + phaseOffset) * maxAngle;
        transform.rotation = initialRotation * Quaternion.Euler(0, 0, angle);
    }

    public void PlayOne()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
