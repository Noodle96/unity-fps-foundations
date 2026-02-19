using UnityEngine;

public class HammerHazard : MonoBehaviour
{
    [Header("Swing Settings")]
    public float maxAngle = 90f;
    public float speed = 2f;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * maxAngle;
        transform.rotation = initialRotation * Quaternion.Euler(0, 0, angle);
    }
}
