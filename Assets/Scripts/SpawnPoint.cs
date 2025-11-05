using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float gizmoBoxHeight = 2.0f;
    public float gizmoBoxWidth = 1.0f;
    public float gizmoArrowLength = 1.0f;

    public void OnDrawGizmos()
    {
        Color boxColor = Color.yellow;
        boxColor.a = 0.5f;

        Gizmos.color = boxColor;

        // Since our box's position is the CENTER of the box, we will want to draw the box 1/2 the height of the box off the ground.
        // Gizmos are drawn in WORLD space, so you need to access the transform component to set their relative position.
        // We will start at our position and then move up.
        Vector3 boxPosition = transform.position;
        boxPosition += Vector3.up * (gizmoBoxHeight / 2);
        // Our size will be square on the X/Z, and only use the height
        Vector3 boxSize = new Vector3(gizmoBoxWidth, gizmoBoxHeight, gizmoBoxWidth);
        Gizmos.DrawCube(boxPosition, boxSize);

        // Now, we set the gizmo color to red for our ray that shows direction
        Gizmos.color = Color.red;
        // And draw the ray in the direction of our spawn
        Gizmos.DrawRay(boxPosition, transform.forward * gizmoArrowLength);
       
    }
}
