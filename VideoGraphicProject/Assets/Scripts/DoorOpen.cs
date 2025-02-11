using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] float open = 100f;
    [SerializeField] float range = 10f;

    [SerializeField] GameObject door;
    [SerializeField] bool isOpening = false;

    [SerializeField] Camera fpsCam;

    [SerializeField] AudioSource src;
    [SerializeField] AudioClip myClip;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("f"))
        {
            Shoot();
            src.Play();
            Debug.Log("Opening");
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(OpenDoor());
            }
        }
    }

        IEnumerator OpenDoor()
    {
        isOpening = true;
        door.GetComponent<Animator>().Play("DoorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5.0f);
        door.GetComponent<Animator>().Play("New State");
        isOpening = false;
    }
}
