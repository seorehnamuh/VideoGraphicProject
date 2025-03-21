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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickup();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            heldObjectRb.velocity = Vector3.zero;
            heldObject.transform.position = holdPosition.position;
        }
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                heldObjectRb.isKinematic = true;
                heldObject.transform.SetParent(holdPosition);
            }
        }
    }

    void DropObject()
    {
        heldObjectRb.isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
        heldObjectRb = null;
    }
}
