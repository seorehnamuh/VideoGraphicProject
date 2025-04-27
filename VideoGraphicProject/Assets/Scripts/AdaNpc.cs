

using UnityEngine;
using TMPro;

public class AdaNpc : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NpcDialogText;  
    [SerializeField] TextMeshProUGUI notificationText;  
    private bool isPlayerNear = false; 
    private bool canShowDialog = false;  
    [SerializeField] InstructionManager instructionManager;  

    void Start()
    {
        NpcDialogText.gameObject.SetActive(false);  
        notificationText.gameObject.SetActive(false);  
          
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && canShowDialog)
        {
            
            HideNotification();  
            ShowDialog();  
        }
    }

    private void ShowDialog()
    {
        NpcDialogText.gameObject.SetActive(true);  
        NpcDialogText.text = "Thank you, Sergeant Alfa. Check the Cockpit now."; 
    }

    private void ShowNotification()
    {
        
        notificationText.gameObject.SetActive(true);  
        notificationText.text = "Press [E] to talk to Ada.";  
    }

    private void HideNotification()
    {
        
        notificationText.gameObject.SetActive(false);  
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;  

            if (instructionManager.GetCurrentPanelsChecked() == instructionManager.GetTotalPanels())
            {
                canShowDialog = true; 
                ShowNotification();  
            }
        }
    }

   
    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;  
            NpcDialogText.gameObject.SetActive(false);  
            HideNotification();  
        }
    }
}
