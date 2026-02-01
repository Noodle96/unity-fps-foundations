using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject destination1;
    public GameObject destination2;

    void Start()
    {
        navMeshAgent.destination = destination1.transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, destination1.transform.position);
        if (distance < 2) {
            navMeshAgent.destination = destination2.transform.position;
        }
    }
}
