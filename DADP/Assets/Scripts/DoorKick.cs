using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKick : MonoBehaviour
{
    public Animator doorAnimator;
    public string kickTrigger = "Kick";
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            KickDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the collider range
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the collider range
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void KickDoor()
    {
        // Play the kick animation
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Kick");
        }
    }
}
