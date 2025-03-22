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
    { "HistoryPanel3", "After years of mistrust, the first exchanges with the races more open to dialogue begin. Humanity obtains new technologies, while the aliens become interested in human biology, art and psychology." },
    { "HistoryPanel4", "Not all species are happy with humanity’s expansion into space. Some alien groups are starting to actively oppose it, while on Earth, movements are emerging that oppose alien influences." },
    { "HistoryPanel5", "Year 2173. A critical event – ​​the attack of the humans on the Zorathite stone – endangers the fragile coexistence, bringing humanity and some races to the brink of war." },
    { "HistoryPanel6", "After intense diplomatic negotiations, a treaty is signed with some species, establishing borders, trade rules, and laws for peaceful interaction. Not all races accept the agreement, but the majority support it." },
    { "HistoryPanel7", "Over time, human cities become host to alien embassies and vice versa. Scientific cooperation projects, mixed colonies and even interspecies families emerge, while tensions with hostile factions continue to exist." },
    { "HistoryPanel8", "After years of collaboration, humanity becomes an integral part of a great galactic alliance, taking on a political and diplomatic role. However, the galaxy remains divided and new threats could always emerge…" }


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
