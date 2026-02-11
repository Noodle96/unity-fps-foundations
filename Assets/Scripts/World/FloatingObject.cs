using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingObject : MonoBehaviour
{
    [Header("Floating Settings")]
    [Tooltip("Altura máxima del movimiento")]
    public float floatAmplitude = 0.5f;

    [Tooltip("Velocidad de oscilación")]
    public float floatSpeed = 2f;

    [Header("Phase Settings")]
    [Tooltip("0 = normal, PI = invertido")]
    public float phaseOffset = 0f;

    private Vector3 startPosition;
    private float timeCounter;


    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        timeCounter += Time.deltaTime;

        float yOffset = Mathf.Sin(timeCounter * floatSpeed + phaseOffset) * floatAmplitude;
        transform.position = startPosition + Vector3.up * yOffset;

    }
}
