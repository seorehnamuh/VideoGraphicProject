using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject DoorCanvas;
    [SerializeField] GameObject DoorToOpen;

    private Animator DoorAnimator;
    private AudioSource OpeningDoorSound; 
    private bool IsTheDoorOpened;

    private Material Material;
    private Renderer Renderer;

    private bool IsPlayerCloseToTheButton;
    void Start()
    {
        DoorCanvas.SetActive(false);
        IsTheDoorOpened = false;
        DoorAnimator = DoorToOpen.GetComponent<Animator>();
        OpeningDoorSound = DoorToOpen.GetComponent<AudioSource>();
        Renderer = GetComponent<Renderer>();
        Material = Renderer.material;  
        IsPlayerCloseToTheButton = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && IsTheDoorOpened == false)
        {
            DoorCanvas.SetActive(true);
            IsPlayerCloseToTheButton = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.O) && IsPlayerCloseToTheButton)
        {
            OpeningDoorSound.Play();
            DoorAnimator.SetBool("OpenDoor", true);
            IsTheDoorOpened = true;
            Material.SetColor("_EmissionColor", Color.green);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        DoorCanvas.SetActive(false);
        IsPlayerCloseToTheButton = false;
    }

}
