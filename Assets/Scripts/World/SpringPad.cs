using System.Collections;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    [Header("Spring Settings")]
    public float delayBeforeLaunch = 1f;
    public Transform targetPoint;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip springSound;

    private bool isLaunching = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLaunching)
        {
            StartCoroutine(LaunchPlayer(other));
        }
    }

    IEnumerator LaunchPlayer(Collider player)
    {
        isLaunching = true;
        // Sonido
        if (audioSource && springSound)
            audioSource.PlayOneShot(springSound);
        // Espera 2 segundos
        //yield return new WaitForSeconds(delayBeforeLaunch);

        

        // Obtener script del jugador
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            Vector3 start = player.transform.position;
            Vector3 end = targetPoint.position;

            float gravity = Mathf.Abs(Physics.gravity.y);

            // Diferencias
            float heightDifference = end.y - start.y;
            Vector3 planarDifference = new Vector3(end.x - start.x, 0f, end.z - start.z);

            float time = 1.2f; // Tiempo del salto (puedes ajustar)

            Vector3 velocityY = Vector3.up *
                (heightDifference / time + 0.5f * gravity * time);

            Vector3 velocityXZ = planarDifference / time;

            Vector3 finalVelocity = velocityXZ + velocityY;

            playerMovement.ApplyExternalForce(finalVelocity);
        }

        yield return new WaitForSeconds(1f);

        isLaunching = false;
    }
}
