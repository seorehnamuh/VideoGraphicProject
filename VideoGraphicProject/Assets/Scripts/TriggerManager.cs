using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI guiText;
    private Dictionary<string, string> objectsWithMessages;
   
    void Start()
    {
        guiText.enabled = false;

        objectsWithMessages = new Dictionary<string, string>
        {
          { "MainHallMapsTrigger", "Starship Maps Level 1" },
          { "TheBermudaTriangleTrigger", "The Bermuda Triangle, a mysterious stretch of ocean has swallowed ships and planes without a trace for centuries. Some say it's a gateway to another dimension, others whisper of a magnetic force so strong it bends time itself." },
          
        

        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        string gameObjectTag = other.gameObject.tag;
        if (objectsWithMessages.ContainsKey(gameObjectTag))
        {
            StartCoroutine(ShowMessage(gameObjectTag, 3));
        }

    }

    IEnumerator ShowMessage(string gameObjectTag, float delay)
    {
            string message = objectsWithMessages[gameObjectTag];
            guiText.text = message;
            guiText.enabled = true;
            yield return new WaitForSeconds(delay);
            guiText.enabled = false;
        
    }
}
