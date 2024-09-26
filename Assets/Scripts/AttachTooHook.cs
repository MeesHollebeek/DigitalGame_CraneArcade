using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTooHook : MonoBehaviour
{
    private GameObject objectToPickUp;  // The object to be picked up or attached
    private GameObject attachedObject;  // The currently attached object
    private bool isObjectInRange = false;  // To track if hook is in contact with "Pickable" object

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If there's an object attached, detach it
            if (attachedObject != null)
            {
                DetachObject();
            }
            // If there's no object attached, attach the object if it's in range
            else if (isObjectInRange && objectToPickUp != null)
            {
                AttachObjectToHook();
            }
        }
    }

    // When the hook enters a trigger collider with the tag "Pickable"
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Pickable" tag
        if (other.CompareTag("Pickable"))
        {
            isObjectInRange = true;
            objectToPickUp = other.gameObject;
        }
    }

    // When the hook exits the trigger collider, it no longer can pick up the object
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            isObjectInRange = false;
            objectToPickUp = null;
        }
    }

    // Method to attach the object to the hook
    private void AttachObjectToHook()
    {
        attachedObject = objectToPickUp;
        attachedObject.transform.SetParent(transform);
        attachedObject.transform.localPosition = Vector3.zero;  // Optional: Position it relative to the hook

        // Optionally, disable the rigidbody to avoid unwanted physics behavior
        Rigidbody objectRigidbody = attachedObject.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }

        // Once picked up, the object should no longer be picked again until detached
        isObjectInRange = false;
        objectToPickUp = null;
    }

    // Method to detach the object from the hook
    private void DetachObject()
    {
        if (attachedObject != null)
        {
            // Re-enable the rigidbody to let physics affect the object again
            Rigidbody objectRigidbody = attachedObject.GetComponent<Rigidbody>();
            if (objectRigidbody != null)
            {
                objectRigidbody.isKinematic = false;
            }

            // Remove the object as the child of the hook
            attachedObject.transform.SetParent(null);

            // Clear the attached object reference
            attachedObject = null;
        }
    }



}
