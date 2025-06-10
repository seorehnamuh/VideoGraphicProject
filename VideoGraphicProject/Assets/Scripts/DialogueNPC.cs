
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogoNPC : MonoBehaviour
{
    [SerializeField] GameObject porta;
    [SerializeField] TMP_Text dialogoText;
    [SerializeField] TMP_Text notificationText;
    [SerializeField] string[] dialogoNPC;

    [SerializeField] AudioClip suonoAperturaPorta; 
    private AudioSource audioSource;  

    private bool nelRaggio = false;
    private bool dialogoAttivo = false;
    private int indiceDialogo = 0;

    private void Start()
    {
        dialogoText.gameObject.SetActive(false);
        notificationText.gameObject.SetActive(false);

      
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nelRaggio = true;

            if (!dialogoAttivo)
            {
                StartCoroutine(MostraMessaggioTemporaneo("Press [E] to interact", 2f));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nelRaggio = false;
            FineDialogo();
            notificationText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (nelRaggio && Input.GetKeyDown(KeyCode.E))
        {

            if (!dialogoAttivo)
            {
                notificationText.gameObject.SetActive(false);
                IniziaDialogo();
            }
            else
            {
                
                AvanzaDialogo();
            }
        }
    }

    void IniziaDialogo()
    {
        dialogoAttivo = true;
        indiceDialogo = 0;
        dialogoText.gameObject.SetActive(true);
        dialogoText.text = dialogoNPC[indiceDialogo];
    
    }

    void AvanzaDialogo()
    {
        indiceDialogo++;

        if (indiceDialogo < dialogoNPC.Length)
        {
            dialogoText.text = dialogoNPC[indiceDialogo];
        
        }
        else
        {
            
            FineDialogo();
            porta.SetActive(false);

    
            if (suonoAperturaPorta != null && audioSource != null)
            {
                audioSource.PlayOneShot(suonoAperturaPorta);
            }
        }
    }

    void FineDialogo()
    {
        dialogoText.gameObject.SetActive(false);
        dialogoAttivo = false;

    }

    IEnumerator MostraMessaggioTemporaneo(string messaggio, float durata)
    {
        notificationText.text = messaggio;
        notificationText.gameObject.SetActive(true);
        yield return new WaitForSeconds(durata);
        notificationText.gameObject.SetActive(false);
    }
}
