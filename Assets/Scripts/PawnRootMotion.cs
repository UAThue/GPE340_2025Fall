using UnityEngine;

public class PawnRootMotion : Pawn
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void MoveTo(Vector3 moveTarget)
    {
        // Rotate towards point, 
        RotateToLookAt(moveTarget);

        // Move Forward
        animator.SetFloat("Vertical", movementSpeed);
    }


    public override void Move(Vector3 moveDirection)
    {
        animator.SetFloat("Horizontal", moveDirection.x * movementSpeed);
        animator.SetFloat("Vertical", moveDirection.z * movementSpeed);
    }

    public override void DodgeRoll()
    {
        animator.SetTrigger("DodgeRoll");
    }

    public override void Rotate(float rotationAngle)
    {
        transform.Rotate(0.0f, rotationAngle * rotationSpeed * Time.deltaTime, 0.0f);
    }

    public override void RotateToLookAt(Vector3 targetPoint)
    {
        // Find the vector from our position to the target point
        Vector3 lookVector = targetPoint - transform.position;

        // Find the rotation that will look down that vector with world up being the up direction
        Quaternion lookRotation = Quaternion.LookRotation(lookVector, Vector3.up);

        // Rotate slightly towards that target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    public void OnAnimatorMove()
    {
        // After the animation runs
        // Use root motion to move the game object
        transform.position = animator.rootPosition;
        transform.rotation = animator.rootRotation;

        // If we have a NavMeshAgent on our controller,
        ControllerAI aiController = controller as ControllerAI;
        if (aiController != null)
        {
            // Set our navMeshAgent to understand it is as the position from the animator
            aiController.agent.nextPosition = animator.rootPosition;
        }
    }

    public void OnAnimatorIK()
    {
        if (weapon == null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
            return;
        }

        // If that weapon has a right hand IK point
        if (weapon.rightHandIKTarget != null)
        {
            animator.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandIKTarget.position);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            animator.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandIKTarget.rotation);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }

        // Same with left hand
        if (weapon.leftHandIKTarget != null)
        {
            animator.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandIKTarget.position);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandIKTarget.rotation);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
    }
}
