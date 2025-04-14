// using UnityEngine;
// using TMPro;
// using System.Collections;

// public class DialogoNPC : MonoBehaviour
// {
//     public GameObject porta;
//     public TMP_Text dialogoText;
//     public TMP_Text notificationText;
//     public string[] dialogoNPC;

//     private bool nelRaggio = false;
//     private bool dialogoAttivo = false;
//     private int indiceDialogo = 0;

//     private void Start()
//     {
//         dialogoText.gameObject.SetActive(false);
//         notificationText.gameObject.SetActive(false);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("✅ Player è entrato nel trigger");
//             nelRaggio = true;

//             if (!dialogoAttivo)
//             {
//                 StartCoroutine(MostraMessaggioTemporaneo("Press [E] to interact", 2f));
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("❌ Player è uscito dal trigger");
//             nelRaggio = false;
//             FineDialogo();
//             notificationText.gameObject.SetActive(false);
//         }
//     }

//     private void Update()
//     {
//         if (nelRaggio && Input.GetKeyDown(KeyCode.E))
//         {
//             Debug.Log("⌨️ Tasto E premuto");

//             if (!dialogoAttivo)
//             {
//                 Debug.Log("🟡 Inizio dialogo");
//                 notificationText.gameObject.SetActive(false);
//                 IniziaDialogo();
//             }
//             else
//             {
//                 Debug.Log("➡️ Avanza dialogo");
//                 AvanzaDialogo();
//             }
//         }
//     }

//     void IniziaDialogo()
//     {
//         dialogoAttivo = true;
//         indiceDialogo = 0;
//         dialogoText.gameObject.SetActive(true);
//         dialogoText.text = dialogoNPC[indiceDialogo];
//         Debug.Log("🗨️ Mostra frase: " + dialogoNPC[indiceDialogo]);
//     }

//     void AvanzaDialogo()
//     {
//         indiceDialogo++;

//         if (indiceDialogo < dialogoNPC.Length)
//         {
//             dialogoText.text = dialogoNPC[indiceDialogo];
//             Debug.Log("🗨️ Mostra frase: " + dialogoNPC[indiceDialogo]);
//         }
//         else
//         {
//             Debug.Log("🚪 Fine dialogo, disattivo porta");
//             FineDialogo();
//             porta.SetActive(false);
//         }
//     }

//     void FineDialogo()
//     {
//         dialogoText.gameObject.SetActive(false);
//         dialogoAttivo = false;
//         Debug.Log("🔕 Dialogo chiuso");
//     }

//     IEnumerator MostraMessaggioTemporaneo(string messaggio, float durata)
//     {
//         notificationText.text = messaggio;
//         notificationText.gameObject.SetActive(true);
//         yield return new WaitForSeconds(durata);
//         notificationText.gameObject.SetActive(false);
//     }
// }


using UnityEngine;
using TMPro;
using System.Collections;

public class DialogoNPC : MonoBehaviour
{
    public GameObject porta;
    public TMP_Text dialogoText;
    public TMP_Text notificationText;
    public string[] dialogoNPC;

    // Nuove variabili per il suono
    public AudioClip suonoAperturaPorta;  // Il suono da riprodurre
    private AudioSource audioSource;  // Il componente AudioSource

    private bool nelRaggio = false;
    private bool dialogoAttivo = false;
    private int indiceDialogo = 0;

    private void Start()
    {
        dialogoText.gameObject.SetActive(false);
        notificationText.gameObject.SetActive(false);

        // Ottieni il componente AudioSource attaccato allo stesso GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player è entrato nel trigger");
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
            Debug.Log("❌ Player è uscito dal trigger");
            nelRaggio = false;
            FineDialogo();
            notificationText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (nelRaggio && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("⌨️ Tasto E premuto");

            if (!dialogoAttivo)
            {
                Debug.Log("🟡 Inizio dialogo");
                notificationText.gameObject.SetActive(false);
                IniziaDialogo();
            }
            else
            {
                Debug.Log("➡️ Avanza dialogo");
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
        Debug.Log("🗨️ Mostra frase: " + dialogoNPC[indiceDialogo]);
    }

    void AvanzaDialogo()
    {
        indiceDialogo++;

        if (indiceDialogo < dialogoNPC.Length)
        {
            dialogoText.text = dialogoNPC[indiceDialogo];
            Debug.Log("🗨️ Mostra frase: " + dialogoNPC[indiceDialogo]);
        }
        else
        {
            Debug.Log("🚪 Fine dialogo, disattivo porta");
            FineDialogo();
            porta.SetActive(false);

            // Riproduce il suono quando la porta viene disattivata
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
        Debug.Log("🔕 Dialogo chiuso");
    }

    IEnumerator MostraMessaggioTemporaneo(string messaggio, float durata)
    {
        notificationText.text = messaggio;
        notificationText.gameObject.SetActive(true);
        yield return new WaitForSeconds(durata);
        notificationText.gameObject.SetActive(false);
    }
}
