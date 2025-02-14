using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject DoorUno;
    [SerializeField] bool doorIsOpening;

    [SerializeField] AudioSource src;
    [SerializeField] AudioClip myClip;

    void Update() {
        if (doorIsOpening == true) {
            DoorUno.transform.Translate (Vector3.up * Time.deltaTime * 5);
        }

        if (DoorUno.transform.position.y > 7f) {
            doorIsOpening = false;
        }
    }

    void OnMouseDown() {
        doorIsOpening = true;
        src.Play();
        Debug.Log("Opening");
    }
}
