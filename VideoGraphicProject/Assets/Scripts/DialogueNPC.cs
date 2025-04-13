using System.Collections;
using UnityEngine;
using TMPro; // Importa il namespace di TextMesh Pro

public class DialogoNPC : MonoBehaviour
{
    public GameObject porta; // Riferimento alla porta
    public Animator animPorta; // Animator della porta per gestire l'animazione
    public TMP_Text dialogoText; // Riferimento al testo del dialogo (TextMesh Pro)
    public string[] dialogoNPC; // Array di frasi che l'NPC dice
    private bool nelRaggio = false; // Se il player è nel raggio di trigger

    private int indiceDialogo = 0;


    // Trigger del dialogo quando il player entra nell'area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nelRaggio = true;
            MostraDialogo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nelRaggio = false;
            NascondiDialogo();
        }
    }

    private void Update()
    {
        // Se il player è nel raggio, premere il tasto E per interagire
        if (nelRaggio && Input.GetKeyDown(KeyCode.E))
        {
            if (indiceDialogo < dialogoNPC.Length)
            {
                // Iniziamo l'effetto di scrittura lettera per lettera
                StartCoroutine(ScritturaEffetto(dialogoNPC[indiceDialogo]));
                indiceDialogo++;
            }
            else
            {
                // Una volta finito il dialogo, l'NPC aprirà la porta
                ApriPorta();
                NascondiDialogo();
            }
        }
    }

    // Mostra il testo del dialogo
    void MostraDialogo()
    {
        dialogoText.gameObject.SetActive(true);
        StartCoroutine(ScritturaEffetto(dialogoNPC[indiceDialogo])); // Avvia l'effetto di scrittura lettera per lettera
    }

    // Nascondi il testo del dialogo
    void NascondiDialogo()
    {
        dialogoText.gameObject.SetActive(false);
    }

    // Funzione per far aprire la porta tramite l'animazione
    void ApriPorta()
    {
        if (animPorta != null)
        {
            animPorta.SetBool("openDoor", true);
        }
    }

    // Coroutine per l'effetto di scrittura lettera per lettera
    IEnumerator ScritturaEffetto(string testo)
    {
        dialogoText.text = ""; // Pulisce il testo precedente
        foreach (char lettera in testo.ToCharArray())
        {
            dialogoText.text += lettera; // Aggiungi una lettera alla volta
            yield return new WaitForSeconds(0.05f); // Imposta il tempo di attesa tra ogni lettera
        }
    }
}
