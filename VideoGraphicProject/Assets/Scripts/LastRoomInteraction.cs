using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastRoomInteraction : MonoBehaviour
{
    [SerializeField] TMP_Text interactionText; 
    
    public float displayDistance = 3f;

    private Transform playerTransform;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}