using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [Header("NavMesh")]
    public NavMeshAgent navMeshAgent;

    [Header("Patrol")]
    public Transform[] destinations;
    public float patrolStopDistance = 0.5f;

    private int index = 0;
    private int lastIndex = -1;


    [Header("Player Detection")]
    public bool followPlayer = true;
    [Header("DistanceToFollowPlayer = attackRange")]
    public float distanceToFollowPlayer = 10f;
    public float attackStopDistance = 8f;


    private GameObject player;
    private float distanceToPlayer;
    //public float distanceToFollowPath = 2f;

    [Header("Sound")]
    private AudioSource audioSource;
    public AudioClip chaseSound;

    void Start()
    {
        // Initialize Audio Source
        audioSource = GetComponent<AudioSource>();
        if(audioSource != null && chaseSound != null) {
            audioSource.clip = chaseSound;
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.Play();
        }
        player = Object.FindFirstObjectByType<PlayerMovement>().gameObject;  //FindObjectOfType<PlayerMovement>().gameObject;
        if (destinations.Length > 0) {
            navMeshAgent.stoppingDistance = patrolStopDistance;
            navMeshAgent.destination = destinations[0].position;
        }
    }

    void Update()
    {
        if (player == null) return;

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer  && followPlayer)
        {
            FollowPlayer();
        }
        else {
            EnemyPath();
        }
    }

    void EnemyPath() {
        if (destinations.Length == 0) return;

        navMeshAgent.stoppingDistance = patrolStopDistance;
        navMeshAgent.destination = destinations[index].position;
        //if (Vector3.Distance(transform.position, destinations[index].position) < distanceToFollowPath) {
        //    index = GetRandomIndex();
        //}
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
            index = GetRandomIndex();
        }
    }

    // =======================
    // Follow / Attack logic
    // =======================
    void FollowPlayer() {
        navMeshAgent.stoppingDistance = attackStopDistance;
        navMeshAgent.destination = player.transform.position;
    }

    int GetRandomIndex()
    {
        if (destinations.Length <= 1) return 0;

        int newIndex;
        do
        {
            newIndex = Random.Range(0, destinations.Length);
        } while (newIndex == lastIndex);

        lastIndex = newIndex;
        return newIndex;
    }
}
