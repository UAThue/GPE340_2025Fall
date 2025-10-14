using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Data")]
    public float damageDone = 1.0f;

    [Header("Weapon Events")]
    //All data that our weapon needs       
    public UnityEvent onTriggerPressed;
    public UnityEvent onTriggerReleased;
    public UnityEvent onAltFirePressed;
    public UnityEvent onAltFireReleased;
}
