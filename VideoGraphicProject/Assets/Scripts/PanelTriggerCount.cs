

using UnityEngine;

public class PanelCollisionCount : MonoBehaviour
{
    public InstructionManager instructionManager;  // Riferimento allo script InstructionManager

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se il giocatore entra in collisione con il pannello
        if (collision.gameObject.CompareTag("Player"))  // Verifica il tag del player
        {
            Debug.Log("Giocatore ha colpito il pannello!");

            // Verifica se il pannello è nel layer giusto
            if (gameObject.layer == LayerMask.NameToLayer("Pannello"))
            {
                Debug.Log("Il pannello è nel layer giusto!");
                instructionManager.PanelChecked();  // Chiama la funzione per incrementare il conteggio dei pannelli controllati
                Debug.Log("Conteggio pannelli: " + InstructionManager.panelsChecked);  // Mostra il conteggio aggiornato dei pannelli
            }
            else
            {
                Debug.LogWarning("Il pannello NON è nel layer 'Pannello'!");
            }
        }
    }
}
