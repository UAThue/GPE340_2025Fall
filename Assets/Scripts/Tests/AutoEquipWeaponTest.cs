using UnityEngine;

public class AutoEquipWeaponTest : MonoBehaviour
{
    public Pawn pawn;
    public Weapon weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pawn.EquipWeapon(weapon);
    }

}
