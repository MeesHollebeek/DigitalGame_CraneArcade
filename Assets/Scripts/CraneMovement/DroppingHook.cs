using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingHook : MonoBehaviour
{
    public Transform frontPoint;  // Position to move towards
    public Transform backPoint;   // Position to move backward
    public Transform groundReference; // Reference for ground level
    public Transform maxHeightReference; // Reference for max height

    public float groundOffset = 0;  // Offset to raise the ground level
    public float maxHeightOffset = 0; // Offset to lower the max height

    private float groundLevel;
    private float maxHeight;

    public bool goingForward;
    public bool goingBackward;
    public bool goingUp;
    public bool goingDown;

    void Start()
    {
        // Calculate ground and max height based on references and offsets
        groundLevel = groundReference.position.y + groundOffset;
        maxHeight = maxHeightReference.position.y + maxHeightOffset;
        InitializeHook(); // Set initial position of the hook
    }

    void InitializeHook()
    {
        // Set the hook's initial position based on ground level
        transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
    }

    void Update()
    {
        // Movement logic for the hook
        MoveHook();
        ClampHeight(); // Ensure the hook stays within height limits
    }

    void MoveHook()
    {
        // Move vertically
        if (goingUp)
        {
            transform.position += Vector3.up * Time.deltaTime; // Move up
        }

        if (goingDown)
        {
            transform.position += Vector3.down * Time.deltaTime; // Move down
        }

        // Move horizontally towards front and back points
        if (goingForward)
        {
            MoveToPoint(frontPoint.position);
        }

        if (goingBackward)
        {
            MoveToPoint(backPoint.position);
        }
    }

    void MoveToPoint(Vector3 targetPosition)
    {
        // Move horizontally towards the target position while maintaining current Y
        Vector3 target = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime); // Speed can be adjusted
    }

    void ClampHeight()
    {
        // Clamp the hook's height to stay within limits
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }

        if (transform.position.y < groundLevel)
        {
            transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
        }
    }
}
