using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("References")]
    public GameObject enemyBullet;
    public Transform spawnBulletPoint;
    public Transform playerPosition;

    [Header("Shoot Settings")]
    [Header("attackRange = DistanceToFollowPlayer")]
    public float attackRange = 15f;

    public float bulletForce = 20f;
    public float shootCooldown = 3f;

    private float nextShootTime;

    void Start()
    {
        if (playerPosition == null){
            playerPosition = Object.FindFirstObjectByType<PlayerMovement>().transform;
        }
    }

    void Update()
    {
        if (playerPosition == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);

        if (distanceToPlayer <= attackRange && Time.time >= nextShootTime)
        {
            //Debug.Log("distanceToPlayer <= 10");
            ShootPlayer();
        }
    }

    private void ShootPlayer() { 
    
        Vector3 playerDirection = (playerPosition.position - spawnBulletPoint.position).normalized;
        GameObject newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(playerDirection * bulletForce, ForceMode.Impulse);
        }
        nextShootTime = Time.time + shootCooldown;
        //Destroy(newBullet, 5f);
    }
}
