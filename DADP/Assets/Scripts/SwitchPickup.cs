using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPickup : MonoBehaviour
{
    private bool isPickedUp = false;
    private bool inRange = false;
    public GameObject electricalBox; 

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.E) && inRange && !isPickedUp)
        {
            isPickedUp = true;
            gameObject.SetActive(false);
            Debug.Log("Switch picked up");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Player in range to pick up the switch");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("Player out of range for picking up the switch");
        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}