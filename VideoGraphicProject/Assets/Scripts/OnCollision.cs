using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Animator anim;

    // void Start() {
    //     anim = GetComponent<Animator>();
    // }

    // void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag.Equals("DoorButton")) {
    //         // anim.Play();
    //         Debug.Log("hit");
    //     }
    // }

    [SerializeField] Animator anim;

    void OnTriggerEnter(Collider other){
    if (other.gameObject.CompareTag("DoorButton"))
        {
            anim.Play("DoorOpenAnimation");
            Debug.Log("hit");
        }
    }
}
