using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector] public Controller controller;
    public float movementSpeed;
    public float rotationSpeed;
    public Transform weaponMountPoint;
    public Weapon weapon;

    public abstract void Move(Vector3 moveDirection);
    public abstract void MoveTo(Vector3 moveTarget);
    public abstract void DodgeRoll();
    public abstract void Rotate(float rotationAngle);
    public abstract void RotateToLookAt(Vector3 pointToLookAt);
    public virtual void EquipWeapon(Weapon newWeapon)
    {
        // Set the weapon variable
        weapon = newWeapon;

        // Attach weapon to player
        weapon.transform.position = weaponMountPoint.position;
        weapon.transform.parent = weaponMountPoint.transform.parent;
    }
    public virtual void UnequipWeapon()
    {
        weapon = null;
    }
}
