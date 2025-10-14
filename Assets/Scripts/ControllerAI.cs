using UnityEngine;
using UnityEngine.AI;

public class ControllerAI : Controller
{
    [HideInInspector] public NavMeshAgent agent;
    public Transform targetTransform;
    public float stoppingDistance = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pawn != null)
        {
            Possess(pawn);
        }
    }


    /// <summary>
    /// Update is called once per frame 
    /// </summary>
    void Update()
    {
        // If we don't have a pawn, we can't make decisions for it, so do nothing
        if (pawn == null)
        {
            return;
        }

        // Set our NavMeshAgent to seek our target
        agent.SetDestination(targetTransform.position);

        // Find the velocity that the agent wants to move in order to follow the path
        Vector3 desiredVelocity = agent.desiredVelocity;

        desiredVelocity = pawn.transform.InverseTransformDirection(desiredVelocity);

        // Send the direction in to our Move function (use the move function to add speed)
        pawn.Move(desiredVelocity.normalized);

        // Look towards the player
        pawn.RotateToLookAt(targetTransform.position);
    }

    /// <summary>
    /// Possesses a pawn, adding the required elements for AI Navigation
    /// </summary>
    /// <param name="pawnToPossess">The Pawn to Possess</param>
    public override void Possess(Pawn pawnToPossess)
    {
        // Run the Possess from the parent class
        base.Possess(pawnToPossess);

        // Add a nav mesh agent if there isn't one
        agent = pawnToPossess.gameObject.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = pawnToPossess.gameObject.AddComponent<NavMeshAgent>();
        }

        // Set the stopping distance
        agent.stoppingDistance = stoppingDistance;

        // Set the max speed of the AI from the pawn data
        agent.speed = pawn.movementSpeed;
        
        // Set the max rotation speed of the AI from the pawn data
        agent.angularSpeed = pawn.rotationSpeed;

        // Disable the NavMesh Agent actually causing movement
        // Disable movement and rotation from the NavMeshAgent
        agent.updatePosition = false;
        agent.updateRotation = false;   
        
    }

    public override void UnPossess()
    {
        // Remove the NavMeshAgent
       // Destroy(agent);

        // Set the variables (from the base class's definition)
        base.UnPossess();
    }
}
