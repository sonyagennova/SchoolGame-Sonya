using UnityEngine;
using UnityEngine.AI;

public class RandomNavMeshMovement : MonoBehaviour
{
    public float roamRadius = 10f;  // Radius within which the animal can roam
    public float waitTime = 2f;     // Time to wait before moving again

    private NavMeshAgent agent;
    private bool isWaiting = false;

    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomPosition();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            StartCoroutine(WaitAndMove());
        }

        if (agent.velocity.sqrMagnitude > 0.1f)
    {
        animator.SetBool("isWalking", true);
    }
    else
    {
        animator.SetBool("isWalking", false);
    }
    }

    void MoveToRandomPosition()
    {
        // Generate a random position within the roamRadius
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;
        NavMeshHit hit;

        // Find a valid NavMesh position near the random position
        if (NavMesh.SamplePosition(randomDirection, out hit, roamRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    System.Collections.IEnumerator WaitAndMove()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        MoveToRandomPosition();
    }
}
