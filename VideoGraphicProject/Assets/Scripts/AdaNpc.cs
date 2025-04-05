

using UnityEngine;
using TMPro;  // Importa TextMeshPro

public class AdaNpc : MonoBehaviour
{
    public TextMeshProUGUI dialogText;  // Usa TextMeshProUGUI per il testo del dialogo
    private bool isPlayerNear = false;  // Per sapere se il giocatore è vicino all'NPC
    public InstructionManager instructionManager;  // Riferimento allo script InstructionManager

    void Start()
    {
        dialogText.gameObject.SetActive(false);  // Nasconde il dialogo all'inizio
    }

    void Update()
    {
        // Debug per controllare il valore di panelsChecked
        Debug.Log("Pannelli controllati: " + InstructionManager.panelsChecked);

        // Se il giocatore è vicino all'NPC e preme il tasto "E" e ha controllato tutti i pannelli
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && InstructionManager.panelsChecked == instructionManager.totalPanels)
        {
            Debug.Log("Dialogo attivato con Ada");  // Verifica se la condizione è vera
            ShowDialog();  // Mostra il dialogo con Ada
        }
        else if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pannelli non ancora controllati: " + InstructionManager.panelsChecked);  // Mostra un messaggio di debug
        }
    }

    // Mostra il dialogo di Ada
    private void ShowDialog()
    {
        dialogText.gameObject.SetActive(true);  // Attiva il testo del dialogo
        dialogText.text = "Thank you, Sergean Alfa. Check the Cockpit now.";  // Messaggio di Ada
    }

    // Quando il giocatore entra nel trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;  // Il giocatore è vicino ad Ada
            
        }
    }

    // Quando il giocatore esce dal trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;  // Il giocatore non è più vicino
            dialogText.gameObject.SetActive(false);  // Nasconde il dialogo quando il giocatore esce dall'area
            Debug.Log("Giocatore lontano da Ada!");  // Verifica che il giocatore esca dal trigger
        }
    }
}
