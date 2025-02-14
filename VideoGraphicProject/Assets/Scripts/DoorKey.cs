using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField] bool doorKey;
    [SerializeField] GameObject Key;

    void Start() {
        doorKey = false;
    }

    void OnMouseDown() {
        doorKey = true;
        Debug.Log("Key true");
    }
}
