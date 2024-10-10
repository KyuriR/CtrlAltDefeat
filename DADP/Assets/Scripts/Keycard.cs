using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject Keycard;
    public GameObject Inventory;

    public bool inReach;
    
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        Inventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("PickUp"))
        {
            Keycard.SetActive(false);
            Inventory.SetActive(true);
        }
    }
}
