using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Settings")]
    public GameObject door; 
    public string requiredTag = "KeyObject"; 
    public float moveDistance = 0.1f; 
    public float doorOpenSpeed = 2f; 

    private Vector3 initialPosition;
    private Vector3 pressedPosition;
    private bool isPressed = false;
    private float doorTargetY; 

    void Start()
    {
        initialPosition = transform.position;
        pressedPosition = initialPosition - new Vector3(0, moveDistance, 0);

        if (door != null)
        {
            doorTargetY = door.transform.position.y + 3.5f;
        }
    }

    void Update()
    {
       
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
            transform.position = pressedPosition;
            Debug.Log("True");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            isPressed = false;
            transform.position = initialPosition; 
        }
    }
}