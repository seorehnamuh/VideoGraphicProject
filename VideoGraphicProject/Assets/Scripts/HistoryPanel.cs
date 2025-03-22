using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HistoryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guiText; 
    [SerializeField] private AudioSource audioSource; 

    private Dictionary<string, string> objectsWithMessages; 

    void Start()
    {
        guiText.enabled = false; 
       objectsWithMessages = new Dictionary<string, string>
        {
     
    { "HistoryPanel1", "Year 2124. Humanity detects an alien ship near the Solar System for the first time. After months of attempting communication, the first encounter with an extraterrestrial species takes place, causing global shock and wonder." },
    { "HistoryPanel2", "As space exploration progresses, humanity discovers that there is not just one alien race, but many, with different levels of development and cultures. Some are friendly, others suspicious or hostile." },
    { "HistoryPanel3", "After years of mistrust, the first exchanges with the races more open to dialogue begin. Humanity obtains new technologies, while the aliens become interested in human biology, art and psychology." }
        };
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            guiText.text = objectsWithMessages[gameObject.tag];
            guiText.enabled = true;

            
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
     
            guiText.enabled = false;

            
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
