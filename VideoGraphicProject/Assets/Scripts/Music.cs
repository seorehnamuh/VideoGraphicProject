
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Video;

// public class Music : MonoBehaviour
// {
//     public AudioSource[] noteSounds; // Array degli AudioSource per le note
//     public AudioSource errorSound;   // Suono di errore
//     public AudioSource melodySound;  // Suono della melodia di riferimento
//     public VideoPlayer videoPlayer;  // Video da riprodurre
    
//     private List<int> playerInput = new List<int>();
//     private int[] correctSequence = {1, 3, 5, 2, 4, 6, 7}; // Sequenza corretta di tasti
//     private bool isPlayerInTrigger = false;

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             isPlayerInTrigger = true;
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             isPlayerInTrigger = false;
//         }
//     }
    
//     void Update()
//     {
//         Debug.Log("Sequenza corretta");
//         if (!isPlayerInTrigger) return;
        
//         for (int i = 0; i < noteSounds.Length; i++)
//         {
//             if (Input.GetKeyDown(KeyCode.Alpha1 + i))
//             {
//                 PlayNote(i);

//             }
//         }
        
//         if (Input.GetKeyDown(KeyCode.P))
//         {
//             PlayMelody();
//         }
//     }
    
//     void PlayNote(int index)
//     {
//         noteSounds[index].Play();
//         playerInput.Add(index + 1);
        
//         if (playerInput.Count == correctSequence.Length)
//         {
//             CheckSequence();
//         }
//     }
    
//     void PlayMelody()
//     {
//         melodySound.Play();
//     }
    
//     void CheckSequence()
//     {
//         for (int i = 0; i < correctSequence.Length; i++)
//         {
//             if (playerInput[i] != correctSequence[i])
//             {
                
//                 errorSound.Play();
//                 playerInput.Clear();
//                 return;
//             }
//         }
//         Debug.Log("Sequenza corretta");
//          videoPlayer.Play();
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Assicurati di importare TextMesh Pro

public class Music : MonoBehaviour
{
    public AudioSource[] noteSounds; // Array degli AudioSource per le note
    public AudioSource errorSound;   // Suono di errore
    public AudioSource melodySound;  // Suono della melodia di riferimento
    public TextMeshProUGUI winText;  // TextMesh Pro per il messaggio "Hai vinto!"

    private List<int> playerInput = new List<int>();
    private int[] correctSequence = {1, 3, 5, 2, 4, 6, 7}; // Sequenza corretta di tasti
    private bool isPlayerInTrigger = false;

    void Start()
    {
        // All'inizio, nascondi il testo
        if (winText != null)
        {
            winText.gameObject.SetActive(false);  // Nasconde il testo all'inizio
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
    
    void Update()
    {
        if (!isPlayerInTrigger) return;
        
        // Controlla i tasti premuti per le note
        for (int i = 0; i < noteSounds.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                PlayNote(i);
            }
        }
        
        // Se si preme il tasto "P", suona la melodia
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayMelody();
        }
    }
    
    void PlayNote(int index)
    {
        noteSounds[index].Play();
        playerInput.Add(index + 1);
        
        if (playerInput.Count == correctSequence.Length)
        {
            CheckSequence();
        }
    }
    
    void PlayMelody()
    {
        melodySound.Play();
    }
    
    void CheckSequence()
    {
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (playerInput[i] != correctSequence[i])
            {
                // Se la sequenza è errata, suona il suono di errore
                errorSound.Play();
                playerInput.Clear();
                return;
            }
        }
        
        // Quando la sequenza è corretta, mostra il messaggio di vittoria
        Debug.Log("Hai vinto!");
        
        // Mostra il testo "Hai vinto!" solo quando la sequenza è corretta
        if (winText != null)
        {
            winText.text = "The missiles were launched as per the code entered. The Ultimatum spaceship is safe now.";  // Cambia il testo al messaggio di vittoria
            winText.gameObject.SetActive(true);  // Rende visibile il testo
        }
    }
}
