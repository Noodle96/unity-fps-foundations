using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatAmplitude = 0.5f;   // Qué tan alto/bajo se mueve
    public float floatSpeed = 2f;          // Qué tan rápido sube y baja

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = startPosition + Vector3.up * yOffset;
    }
}
