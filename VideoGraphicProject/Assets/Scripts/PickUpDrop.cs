using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa TextMeshPro per gestire il testo UI

public class PickUpDrop : MonoBehaviour
{
    [SerializeField] float pickupRange = 3f;
    [SerializeField] float pickupRadius = 0.5f;
    [SerializeField] Transform holdPosition;
    [SerializeField] TextMeshProUGUI pickupText; // NEW: Riferimento all'UI

    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    private bool isNearObject = false;

    void Start()
    {
        if (pickupText != null)
            pickupText.gameObject.SetActive(false); // Assicura che il testo sia nascosto all'inizio
    }

    void Update()
    {
        DetectNearbyObject();

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
        if (Physics.SphereCast(transform.position, pickupRadius, transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                heldObjectRb.isKinematic = true;
                heldObject.transform.SetParent(holdPosition);
                isNearObject = false;

                if (pickupText != null)
                    pickupText.gameObject.SetActive(false); // Nasconde il testo quando si raccoglie l'oggetto
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

    void DetectNearbyObject()
    {
        RaycastHit hit;
        isNearObject = Physics.SphereCast(transform.position, pickupRadius, transform.forward, out hit, pickupRange) && hit.collider.CompareTag("Pickup");

        if (pickupText != null)
            pickupText.gameObject.SetActive(isNearObject && heldObject == null); // Mostra/Nasconde il testo
    }
}
