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
          { "TheBermudaTriangleTrigger", "The Bermuda Triangle - an ocean stretch has swallowed ships and planes for centuries. " },
          { "GravityAnomalyTrigger", " A gravity anomaly - a place where objects roll uphill, compasses spin erratically, people feel a force pulling them." },
          { "AccessDeniedTrigger", "ACCESS DENIED" },
          { "OpenDoorRequest", "ACCESS DENIED. Ask R2D2 to open the door" },
          { "Alien1Description", "Flying saucers streak across the night sky, defying gravity and vanishing in an instant." },
          { "Alien2Description", "Figures of light appear in the night. No faces, No features, just a pulsing radiance." },
          { "Alien3Description", "Classified recordings reveal impossible craft—defying physics, watching, unafraid." },
          { "ExperimentBlueCapsule", "Experiment 3740 - Creatures from Proxima B, defying the boundaries of known life." },
          

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
            StartCoroutine(ShowMessage(gameObjectTag, 5));
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
