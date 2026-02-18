using UnityEngine;

public class RollingLogHazard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;
    [SerializeField] private LogManager logManager;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float rotationSpeed = 400f;

    private Vector3 direction;

    private void Start()
    {
        direction = (bottomPoint.position - topPoint.position).normalized;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, bottomPoint.position) < 0.5f)
        {
            logManager.LogReachedBottom(this);
        }
    }

    private void Rotate()
    {
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }

    public void ResetToTop()
    {
        transform.position = topPoint.position;
    }
}
