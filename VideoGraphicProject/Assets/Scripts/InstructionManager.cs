using UnityEngine;
using TMPro;  
using System.Collections;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] TMP_Text instructionText;  
    [SerializeField] TMP_Text npcDialogText; 
    private int panelsChecked;  
    private int totalPanels;  
    private float instructionDisplayTime = 7f;  

    void Start()
    {
        totalPanels = 8;
        panelsChecked = 0;
        npcDialogText.gameObject.SetActive(false);  
        instructionText.text = "Let's check the panels and report to Ada..";  
        StartCoroutine(HideInstructionsAfterDelay(instructionDisplayTime));  
    }

   
    private IEnumerator HideInstructionsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  
        instructionText.gameObject.SetActive(false);  
    }


    public void PanelChecked()
    {
        panelsChecked++; 
        Debug.Log("Pannelli controllati: " + panelsChecked);

        instructionText.text = $"Pannelli controllati: {panelsChecked}/{totalPanels}";

        if (panelsChecked == totalPanels)
        {
            Debug.Log("Tutti i pannelli sono stati controllati!");  
            ShowNPCDialog();  
        }
    }

    
    private void ShowNPCDialog()
    {
        npcDialogText.gameObject.SetActive(true);  
        npcDialogText.text = "";  
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Il giocatore ha colpito il pannello!");
            
            if (gameObject.layer == LayerMask.NameToLayer("Pannello"))
            {
                Debug.Log("Il pannello è nel layer giusto!");
                PanelChecked();  
            }
            else
            {
                Debug.LogWarning("Il pannello NON è nel layer 'Pannello'!");
            }
        }
    }

    public int  GetTotalPanels() {
        return totalPanels;
    }

    public int GetCurrentPanelsChecked () {
        return panelsChecked;
    }
}
