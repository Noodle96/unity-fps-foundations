using UnityEngine;

public class CrosshairRaycast : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera aimCamera;              // Tu cámara third person
    [SerializeField] private RectTransform crosshairUI;     // El Image (RectTransform) del crosshair

    [Header("Raycast Settings")]
    [SerializeField] private float maxDistance = 200f;
    [SerializeField] private LayerMask hitMask;             // Qué capas puede golpear (entorno, enemigos, etc.)
    [SerializeField] private bool ignorePlayerLayer = true;

    [Header("Debug")]
    [SerializeField] private bool drawDebugRay = true;

    // Este será el punto del mundo al que se apunta
    public Vector3 AimWorldPoint { get; private set; }

    private int playerLayer;

    private void Awake()
    {
        if (aimCamera == null)
            aimCamera = Camera.main;

        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
        UpdateAimPoint();
        UpdateCrosshairPosition();
    }

    private void UpdateAimPoint()
    {
        Ray ray = new Ray(aimCamera.transform.position, aimCamera.transform.forward);

        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxDistance, hitMask, QueryTriggerInteraction.Ignore);

        // Si quieres ignorar al player aunque esté dentro del hitMask:
        if (hasHit && ignorePlayerLayer && hit.collider.gameObject.layer == playerLayer)
        {
            // Re-lanzamos el raycast ignorando ese collider (simple approach: avanzar un poquito y volver a tirar)
            Vector3 newOrigin = hit.point + ray.direction * 0.05f;
            Ray ray2 = new Ray(newOrigin, ray.direction);
            hasHit = Physics.Raycast(ray2, out hit, maxDistance, hitMask, QueryTriggerInteraction.Ignore);
        }

        if (hasHit)
            AimWorldPoint = hit.point;
        else
            AimWorldPoint = ray.origin + ray.direction * maxDistance;

        if (drawDebugRay)
            Debug.DrawLine(ray.origin, AimWorldPoint, Color.green);
    }

    private void UpdateCrosshairPosition()
    {
        // Convertimos el punto del mundo a posición en pantalla
        Vector3 screenPos = aimCamera.WorldToScreenPoint(AimWorldPoint);

        // Si está detrás de la cámara, lo ocultamos (opcional)
        if (screenPos.z < 0f)
        {
            crosshairUI.gameObject.SetActive(false);
            return;
        }

        if (!crosshairUI.gameObject.activeSelf)
            crosshairUI.gameObject.SetActive(true);

        // Como el Canvas es Screen Space - Overlay, podemos usar screenPos directo
        crosshairUI.position = screenPos;
    }
}
