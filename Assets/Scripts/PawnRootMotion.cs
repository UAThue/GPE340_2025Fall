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
}
