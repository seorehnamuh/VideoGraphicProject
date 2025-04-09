


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    [SerializeField] float pickupRange = 3f; 
    [SerializeField] float pickupRadius = 0.5f; // NEW: Defines how wide the detection area is
    [SerializeField] Transform holdPosition; 
    private GameObject heldObject; 
    private Rigidbody heldObjectRb; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
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
        // NEW: Use SphereCast for a wider detection range
        if (Physics.SphereCast(transform.position, pickupRadius, transform.forward, out hit, pickupRange))
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
