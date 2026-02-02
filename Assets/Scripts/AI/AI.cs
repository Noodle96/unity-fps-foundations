using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int index = 0;
    private int lastIndex = -1;


    [Header("Destinations")]
    public bool followPlayer;

    private GameObject player;

    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10f;
    public float distanceToFollowPath = 2f;

    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;
        player = Object.FindFirstObjectByType<PlayerMovement>().gameObject;  //FindObjectOfType<PlayerMovement>().gameObject;

    }

    void Update()
    {
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
        navMeshAgent.destination = destinations[index].position;
        if (Vector3.Distance(transform.position, destinations[index].position) < distanceToFollowPath) {
            index = GetRandomIndex();
        }
    }

    void FollowPlayer() { 
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
