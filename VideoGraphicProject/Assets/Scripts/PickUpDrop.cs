using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    [SerializeField] float pickupRange = 3f; // Range within which the player can pick up objects
    [SerializeField] Transform holdPosition; // Position where the object will be held (e.g., an empty GameObject as a child of the camera)
    private GameObject heldObject; // Reference to the currently held object
    private Rigidbody heldObjectRb; // Rigidbody of the held object

    void Update()
    {
        // Check for pickup input (e.g., "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                // Try to pick up an object
                TryPickup();
            }
            else
            {
                // Drop the held object
                DropObject();
            }
        }

        // If holding an object, move it to the hold position
        if (heldObject != null)
        {
            heldObjectRb.velocity = Vector3.zero; // Stop any residual movement
            heldObject.transform.position = holdPosition.position;
        }
    }

    void TryPickup()
    {
        // Raycast to detect objects in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            // Check if the object has the "Pickup" tag
            if (hit.collider.CompareTag("Pickup"))
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                heldObjectRb.isKinematic = true; // Disable physics while holding
                heldObject.transform.SetParent(holdPosition); // Attach to hold position
            }
        }
    }

    void DropObject()
    {
        // Re-enable physics and detach the object
        heldObjectRb.isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
        heldObjectRb = null;
    }
}
