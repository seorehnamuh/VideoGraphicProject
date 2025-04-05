

// using UnityEngine;
// using TMPro;  // Importa TextMeshPro

// public class AdaNpc : MonoBehaviour
// {
//     public TextMeshProUGUI dialogText;  // Usa TextMeshProUGUI per il testo del dialogo
//     private bool isPlayerNear = false;  // Per sapere se il giocatore è vicino all'NPC
//     public InstructionManager instructionManager;  // Riferimento allo script InstructionManager
    


//     void Start()
//     {
//         dialogText.gameObject.SetActive(false);  // Nasconde il dialogo all'inizio
//     }

//     void Update()
//     {
//         // Debug per controllare il valore di panelsChecked
//         Debug.Log("Pannelli controllati: " + InstructionManager.panelsChecked);

//         // Se il giocatore è vicino all'NPC e preme il tasto "E" e ha controllato tutti i pannelli
//         if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && InstructionManager.panelsChecked == instructionManager.totalPanels)
//         {
//             Debug.Log("Dialogo attivato con Ada");  // Verifica se la condizione è vera
//             ShowDialog();  // Mostra il dialogo con Ada
            
//         }
//         else if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
//         {
//             Debug.Log("Pannelli non ancora controllati: " + InstructionManager.panelsChecked);  // Mostra un messaggio di debug
//         }
//     }

//     // Mostra il dialogo di Ada

    
//     private void ShowDialog()
//     {
//         dialogText.gameObject.SetActive(true);  // Attiva il testo del dialogo
//         dialogText.text = "Thank you, Sergean Alfa. Check the Cockpit now.";  // Messaggio di Ada
//     //    AdaCanvas.SetActive(true); 
//     }

//     // Quando il giocatore entra nel trigger
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             isPlayerNear = true;  // Il giocatore è vicino ad Ada
            
//         }
//     }

//     // Quando il giocatore esce dal trigger
//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             isPlayerNear = false;  // Il giocatore non è più vicino
//             dialogText.gameObject.SetActive(false);  // Nasconde il dialogo quando il giocatore esce dall'area
//             Debug.Log("Giocatore lontano da Ada!");  // Verifica che il giocatore esca dal trigger
//         }
//     }
// }

using UnityEngine;
using TMPro;

public class AdaNpc : MonoBehaviour
{
    public TextMeshProUGUI NpcDialogText;  // Dialogo dell'NPC
    public TextMeshProUGUI notificationText;  // Testo della notifica
    private bool isPlayerNear = false;  // Verifica se il giocatore è vicino
    private bool canShowDialog = false;  // Controlla se il dialogo può essere mostrato
    public InstructionManager instructionManager;  // Riferimento allo script InstructionManager

    void Start()
    {
        NpcDialogText.gameObject.SetActive(false);  // Nasconde il dialogo all'inizio
        notificationText.gameObject.SetActive(false);  // Nasconde la notifica all'inizio
        Debug.Log("AdaNpc script started.");  // Log di debug
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
        NpcDialogText.gameObject.SetActive(true);  // Attiva il testo del dialogo
        NpcDialogText.text = "Thank you, Sergeant Alfa. Check the Cockpit now.";  // Imposta il testo del dialogo
    }

    private void ShowNotification()
    {
        Debug.Log("Showing notification: 'Press E to talk to Ada'.");
        notificationText.gameObject.SetActive(true);  // Attiva la notifica
        notificationText.text = "Press 'E' to talk to Ada.";  // Imposta il testo della notifica
    }

    private void HideNotification()
    {
        Debug.Log("Hiding notification.");
        notificationText.gameObject.SetActive(false);  // Nasconde la notifica
    }

    // Quando il Player entra in collisione
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with Ada.");
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;  // Il giocatore è vicino a Ada
            Debug.Log("Player is near Ada.");

            // Verifica se tutti i pannelli sono controllati
            if (InstructionManager.panelsChecked == instructionManager.totalPanels)
            {
                canShowDialog = true;  // Il dialogo può essere mostrato
                ShowNotification();  // Mostra la notifica SOLO quando tutti i pannelli sono controllati
            }
        }
    }

    // Quando il Player esce dalla collisione
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player exited collision with Ada.");
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;  // Il giocatore non è più vicino a Ada
            NpcDialogText.gameObject.SetActive(false);  // Nasconde il dialogo
            HideNotification();  // Nasconde la notifica quando il giocatore esce
        }
    }
}
