using UnityEngine;

public class BalancePlatformHazard : MonoBehaviour
{
    [Header("Balance Settings")]
    [SerializeField] private float maxAngle = 15f;
    [SerializeField] private float speed = 2f;

    [Header("Start Offset")]
    [SerializeField] private float startPhase = 0f; // Desfase inicial (en radianes)

    private float startAngle;

    private void Start()
    {
        startAngle = transform.localEulerAngles.x;
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Sin(Time.time * speed + startPhase) * maxAngle;
        transform.localRotation = Quaternion.Euler(startAngle + angle, 0f, 0f);
    }
}
