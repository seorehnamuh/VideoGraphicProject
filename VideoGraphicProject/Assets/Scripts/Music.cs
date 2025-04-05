
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class Music : MonoBehaviour
{
    public AudioSource[] noteSounds; 
    public AudioSource errorSound;  
    public AudioSource melodySound;  
    public TextMeshProUGUI winText; 

    private List<int> playerInput = new List<int>();
    private int[] correctSequence = {1, 3, 5, 2, 4, 6, 7}; 
    private bool isPlayerInTrigger = false;

    void Start()
    {
       
        if (winText != null)
        {
            winText.gameObject.SetActive(false);  
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
        
        for (int i = 0; i < noteSounds.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                PlayNote(i);
            }
        }
        
    
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
             
                errorSound.Play();
                playerInput.Clear();
                return;
            }
        }
        
    
        Debug.Log("Hai vinto!");
        

        if (winText != null)
        {
            winText.text = "The missiles were launched as per the code entered. The Ultimatum spaceship is safe now.";  
            winText.gameObject.SetActive(true);  
        }
    }
}
