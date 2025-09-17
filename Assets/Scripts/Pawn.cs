using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector] public Controller controller;
    public float movementSpeed;
    public float rotationSpeed;

    public abstract void Move(Vector3 moveDirection);
    public abstract void DodgeRoll();
    public abstract void Rotate(float rotationAngle);
}
