using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] TMP_Text interactionText; // Riferimento al componente TextMeshPro UI
    public string message = "Need a Key"; // Messaggio da visualizzare
    public float displayDistance = 3f; // Distanza massima per visualizzare il messaggio

    private Transform playerTransform;
    private bool isPlayerNear = false;

    void Start()
    {
            interactionText.gameObject.SetActive(false);
    }

    // void Update()
    // {
    //     // Se il giocatore è vicino e guarda verso la porta
    //     if (isPlayerNear && playerTransform != null)
    //     {
    //         float distance = Vector3.Distance(transform.position, playerTransform.position);
    //         if (distance <= displayDistance)
    //         {
    //             // Mostra il testo
    //             interactionText.text = message;
    //             interactionText.gameObject.SetActive(true);
    //         }
    //         else
    //         {
    //             // Nascondi il testo se il giocatore è troppo lontano
    //             interactionText.gameObject.SetActive(false);
    //             isPlayerNear = false;
    //         }
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        // Controlla se il giocatore è entrato nel trigger
        if (other.CompareTag("Player"))
        {
            // isPlayerNear = true;
            interactionText.gameObject.SetActive(true);
            Debug.Log("Need key");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Controlla se il giocatore è uscito dal trigger
        if (other.CompareTag("Player"))
        {
            // isPlayerNear = false;
            interactionText.gameObject.SetActive(false);
            Debug.Log("Exit");
        }
    }
}