

using UnityEngine;
using TMPro;  // Usa TMP_Text invece di Text
using System.Collections;

public class InstructionManager : MonoBehaviour
{
    public TMP_Text instructionText;  // Usa TMP_Text invece di Text
    public TMP_Text npcDialogText;  // Usa TMP_Text invece di Text
    public static int panelsChecked = 0;  // Tieni traccia dei pannelli controllati
    public int totalPanels = 8;  // Numero totale di pannelli da controllare
    public float instructionDisplayTime = 7f;  // Tempo in secondi prima che il testo delle istruzioni scompaia

    void Start()
    {
        npcDialogText.gameObject.SetActive(false);  // Nasconde il dialogo NPC all'inizio
        instructionText.text = "Let's check the panels and report to Ada..";  // Mostra le istruzioni
        StartCoroutine(HideInstructionsAfterDelay(instructionDisplayTime));  // Chiama la coroutine per nascondere il testo
    }

    // Coroutine che nasconde il testo delle istruzioni dopo un determinato ritardo
    private IEnumerator HideInstructionsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Attende per il numero di secondi specificato
        instructionText.gameObject.SetActive(false);  // Nasconde il testo delle istruzioni
    }

    // Quando il giocatore entra nel trigger di un pannello (ora collisione fisica)
    public void PanelChecked()
    {
        panelsChecked++;  // Incrementa il numero dei pannelli controllati
        Debug.Log("Pannelli controllati: " + panelsChecked);  // Stampa il numero dei pannelli controllati

        instructionText.text = $"Pannelli controllati: {panelsChecked}/{totalPanels}";

        if (panelsChecked == totalPanels)
        {
            Debug.Log("Tutti i pannelli sono stati controllati!");  // Messaggio quando tutti i pannelli sono controllati
            ShowNPCDialog();  // Mostra il dialogo con l'NPC quando tutti i pannelli sono controllati
        }
    }

    // Mostra il dialogo con l'NPC
    private void ShowNPCDialog()
    {
        npcDialogText.gameObject.SetActive(true);  // Mostra il testo del dialogo
        npcDialogText.text = "";  // Messaggio di Ada
    }
}
