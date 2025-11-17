using UnityEngine;
using System.Collections.Generic;

public class GA_Ragdoll : MonoBehaviour
{
    public bool isRagdoll;
    public float  knockBackForce = 200;
    private Collider mainCollider;
    private Rigidbody mainRigidbody;
    private List<Collider> childColliders;
    private List<Rigidbody> childRigidbodies;
    private Animator mainAnimator;

    void Start()
    {
        // Load our variables
        mainAnimator = GetComponent<Animator>();
        mainCollider = GetComponent<Collider>();
        mainRigidbody = GetComponent<Rigidbody>();

        childColliders = new List<Collider>(GetComponentsInChildren<Collider>());
        childRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        childColliders.Remove(mainCollider);
        childRigidbodies.Remove(mainRigidbody);

        // Turn on ragdoll based on setting in inspector
        SetRagdollFromBool();
    }

    private void SetRagdollFromBool()
    {
        if (isRagdoll)
        {
            EnableRagdoll();
        }
        else
        {
            DisableRagdoll();
        }
    }

    public void EnableRagdoll()
    {
        // Turn off the main collider
        mainCollider.enabled = false;

        // Turn off the main rigidbody
        mainRigidbody.isKinematic = true;

        // Turn off the animator
        mainAnimator.enabled = false;

        // For each through all the rigidbodies in the children of the main object and set isKinematic to false
        foreach ( Rigidbody rb in childRigidbodies )
        {
            rb.isKinematic = false;            
            rb.AddForce(Vector3.up * knockBackForce);
        }

        // For each through all the colliders in the children of the main object and set them to active
        foreach ( Collider collider in childColliders)
        {
            collider.enabled = true;
        }
    }

    public void DisableRagdoll()
    {
        // Turn on the main collider
        mainCollider.enabled = true;

        // Turn on the main rigidbody
        mainRigidbody.isKinematic = false;

        // Turn on the animator
        mainAnimator.enabled = true;

        // For each through all the rigidbodies in the children of the main object and set isKinematic to true
        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.isKinematic = true;
        }

        // For each through all the colliders in the children of the main object and set them to inactive
        foreach (Collider collider in childColliders)
        {
            collider.enabled = false;
        }
    }

    public void ToggleRagdoll()
    {
        isRagdoll = !isRagdoll;
        SetRagdollFromBool();
    }

}
