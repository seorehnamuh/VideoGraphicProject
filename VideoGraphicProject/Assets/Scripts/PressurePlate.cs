using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Settings")]
    public GameObject door; // La porta da aprire/chiudere
    public string requiredTag = "KeyObject"; // Tag dell'oggetto che attiva la piastra
    public float moveDistance = 0.1f; // Quanto si abbassa la piastra quando attivata
    public float doorOpenSpeed = 2f; // Velocità di apertura della porta

    private Vector3 initialPosition;
    private Vector3 pressedPosition;
    private bool isPressed = false;
    private float doorTargetY; // Altezza finale della porta (per apertura verticale)

    void Start()
    {
        initialPosition = transform.position;
        pressedPosition = initialPosition - new Vector3(0, moveDistance, 0);

        if (door != null)
        {
            doorTargetY = door.transform.position.y + 3f; // Apre la porta verso l'alto di 3 unità
        }
    }

    void Update()
    {
        // Muove la porta se è stata assegnata
        if (door != null && isPressed)
        {
            float step = doorOpenSpeed * Time.deltaTime;
            Vector3 targetPosition = new Vector3(door.transform.position.x, doorTargetY, door.transform.position.z);
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, step);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            isPressed = true;
            transform.position = pressedPosition; // La piastra si abbassa
            Debug.Log("True");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            isPressed = false;
            transform.position = initialPosition; // La piastra torna su
        }
    }
}