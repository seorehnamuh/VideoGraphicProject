using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HistoryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guiText; // Riferimento al testo
    [SerializeField] private AudioSource audioSource; // Riferimento all'AudioSource

    private Dictionary<string, string> objectsWithMessages; // Dizionario per messaggi personalizzati

    void Start()
    {
        guiText.enabled = false; // Inizialmente nascondiamo il testo
       objectsWithMessages = new Dictionary<string, string>
        {
     
    { "HistoryPanel1", "Humanity detects an alien ship near the Solar System for the first time. After months of attempting communication, the first encounter with an extraterrestrial species takes place, causing global shock and wonder." } // Aggiungi questa chiave
        };
    }

    // Quando il player entra in collisione con il pannello
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Controlla se l'oggetto è il Player
        {
            // Mostra il messaggio
            guiText.text = objectsWithMessages[gameObject.tag];
            guiText.enabled = true;

            // Riproduce l'audio in loop
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    // Quando il player esce dal pannello
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Controlla se l'oggetto che esce è il Player
        {
            // Nasconde il testo
            guiText.enabled = false;

            // Ferma l'audio
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
