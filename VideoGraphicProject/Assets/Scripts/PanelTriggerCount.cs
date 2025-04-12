

// using UnityEngine;

// public class PanelCollisionCount : MonoBehaviour
// {
//     public InstructionManager instructionManager;  

  
//     private void OnCollisionEnter(Collision collision)
//     {
        
//         if (collision.gameObject.CompareTag("Player"))  
//         {
//             Debug.Log("Giocatore ha colpito il pannello!");

     
//             if (gameObject.layer == LayerMask.NameToLayer("Pannello"))
//             {
//                 Debug.Log("Il pannello è nel layer giusto!");
//                 instructionManager.PanelChecked();  
//                 Debug.Log("Conteggio pannelli: " + instructionManager.GetCurrentPanelsChecked());  
//             }
//             else
//             {
//                 Debug.LogWarning("Il pannello NON è nel layer 'Pannello'!");
//             }
//         }
//     }
// }


using UnityEngine;

public class PanelCollisionCount : MonoBehaviour
{
    public InstructionManager instructionManager;

    private bool isChecked = false; // 👈 Per evitare conteggi doppi

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isChecked && gameObject.layer == LayerMask.NameToLayer("Pannello"))
            {
                Debug.Log("Il pannello è nel layer giusto e non è stato ancora controllato!");
                instructionManager.PanelChecked();
                isChecked = true; // 👈 Impedisce di contare di nuovo questo pannello
            }
            else if (isChecked)
            {
                Debug.Log("Questo pannello è già stato controllato.");
            }
            else
            {
                Debug.LogWarning("Il pannello NON è nel layer 'Pannello'!");
            }
        }
    }
}
