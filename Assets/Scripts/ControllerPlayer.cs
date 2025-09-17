using UnityEngine;

public class ControllerPlayer : Controller
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // If there is a pawn set by the designers, make sure we possess it and make the link bidirectional
        if (pawn != null)
        {
            Possess(pawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        // Get the stick values
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        // Balance the input so it is fair for analog sticks 
        movementVector = Vector3.ClampMagnitude(movementVector, 1);

        // Send to the pawn to move
        pawn.Move(movementVector);

        // Handle Rotation
        if (Input.GetKey(KeyCode.Q)) {
            pawn.Rotate(1.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            pawn.Rotate(-1.0f);
        }

        // Handle Dodge Roll
        if (Input.GetButtonDown("Jump"))
        {
            pawn.DodgeRoll();
        }
    }
}
