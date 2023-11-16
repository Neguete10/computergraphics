using UnityEngine;
using UnityEngine.AI; // Required for NavMesh components

public class CharacterNavigationController : MonoBehaviour
{
    public Transform destinationPoint; // Assign through Unity Inspector
    private NavMeshAgent agent;
    Animator animator;
    bool walking = false;
    VerdictScript verdict;
    //private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //verdict = GetComponent<VerdictScipt>();
        verdict = GameObject.Find("Canvas").GetComponent<VerdictScript>();

        // Start off with the character moving to the destination
        MoveToDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the character is moving by seeing if the NavMeshAgent has a path and is not stopped
        //bool isMoving = agent.hasPath && !agent.isStopped && agent.remainingDistance > agent.stoppingDistance;

        // Set the IsWalking boolean in the Animator to turn on/off the walking animation
        if(agent.transform.position.z <= 9 && !verdict.verdictSelected)
        {
            animator.SetBool("IsWalking", true);
            walking = true;
        }
        else 
        {
            animator.SetBool("IsWalking", false);
            agent.ResetPath();
        }
        if (verdict.verdictSelected)
        {
            Vector3 posVec = new Vector3(8.61f, 0f, 1f);
            agent.transform.position = posVec;
            Quaternion rotQuat = new Quaternion(0f, 0f, 0f, 0f); 
            agent.transform.rotation = rotQuat; 
            verdict.verdictSelected = false;
            //unrender person if not selected, render person that is selected
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
