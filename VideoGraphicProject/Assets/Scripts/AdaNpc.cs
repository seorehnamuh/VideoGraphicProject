

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
        Debug.Log("AdaNpc script started.");  
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && canShowDialog)
        {
            Debug.Log("Player pressed 'E'. Checking if dialog can be shown...");
            HideNotification();  
            ShowDialog();  
        }
    }

    private void ShowDialog()
    {
        Debug.Log("Showing dialog with Ada.");
        NpcDialogText.gameObject.SetActive(true);  
        NpcDialogText.text = "Thank you, Sergeant Alfa. Check the Cockpit now."; 
    }

    private void ShowNotification()
    {
        Debug.Log("Showing notification: 'Press E to talk to Ada'.");
        notificationText.gameObject.SetActive(true);  
        notificationText.text = "Press [E] to talk to Ada.";  
    }

    private void HideNotification()
    {
        Debug.Log("Hiding notification.");
        notificationText.gameObject.SetActive(false);  
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with Ada.");
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;  
            Debug.Log("Player is near Ada.");

            if (instructionManager.GetCurrentPanelsChecked() == instructionManager.GetTotalPanels())
            {
                canShowDialog = true; 
                ShowNotification();  
            }
        }
    }

   
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player exited collision with Ada.");
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;  
            NpcDialogText.gameObject.SetActive(false);  
            HideNotification();  
        }
    }
}
