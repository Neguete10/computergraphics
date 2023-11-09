using UnityEngine;
using UnityEngine.AI; // Required for NavMesh components

public class CharacterNavigationController : MonoBehaviour
{
    public Transform destinationPoint; // Assign through Unity Inspector
    private NavMeshAgent agent;
    Animator animator;
    //private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Start off with the character moving to the destination
        MoveToDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the character is moving by seeing if the NavMeshAgent has a path and is not stopped
        //bool isMoving = agent.hasPath && !agent.isStopped && agent.remainingDistance > agent.stoppingDistance;

        // Set the IsWalking boolean in the Animator to turn on/off the walking animation
        if(agent.transform.position.z <= 9)
        {
            animator.SetBool("IsWalking", true);
            Debug.Log("walking true: " + animator.GetBool("IsWalking"));
        }
        else
        {
            animator.SetBool("IsWalking", false);
            Debug.Log("walking false: " + animator.GetBool("IsWalking"));
            agent.ResetPath();
        }

        // If the character is close enough to the destination, stop the agent
        /*
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Make sure any remaining velocity is considered before stopping completely.
            if (agent.hasPath && agent.velocity.sqrMagnitude == 0f)
            {
                agent.ResetPath(); // Clears the current path
                animator.SetBool("IsWalking", false); // Set the animation to idle
            }
        }
        */
    }

    // This method initiates the movement towards the destination
    public void MoveToDestination()
    {
        if (destinationPoint != null)
        {
            agent.SetDestination(destinationPoint.position);
        }
    }
}
