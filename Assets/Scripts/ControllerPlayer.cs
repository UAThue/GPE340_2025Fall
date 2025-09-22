using UnityEngine;

public class ControllerPlayer : Controller
{

    public bool isLookAtMouse;

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

        // Convert that direction, so that it passing in the local direction that makes the stick work as world direction
        movementVector = pawn.transform.InverseTransformDirection(movementVector);

        // Send to the pawn to move
        pawn.Move(movementVector);

        if (isLookAtMouse)
        {
            // Rotate Towards Mouse
            // Create a plane at the foot of our character
            Plane groundPlane = new Plane(Vector3.up, pawn.transform.position);

            // Create a ray out of our camera in the direction that passes through the mouse position on the screen
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Find where that mouse ray intersects with the plane
            float distanceToIntersect;
            if (groundPlane.Raycast(mouseRay, out distanceToIntersect))
            {
                Vector3 mousePoint = mouseRay.GetPoint(distanceToIntersect);
                pawn.RotateToLookAt(mousePoint);
            }
            else
            {
                Debug.LogWarning("Oops. The camera isn't looking at the ground!");
            }
        } else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pawn.Rotate(1.0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pawn.Rotate(-1.0f);
            }
        }


        // Handle Dodge Roll
        if (Input.GetButtonDown("Jump"))
        {
            pawn.DodgeRoll();
        }
    }
}
