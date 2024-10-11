using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private bool isDoorUnlocked = false;
    private FirstPersonControls firstPersonControls;
    public Animator animator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firstPersonControls = other.GetComponent<FirstPersonControls>();

            if (firstPersonControls != null && firstPersonControls.holdingKey)
            {
                UnlockDoor();
                DestroyKey(firstPersonControls);
            }
            else
            {
                Debug.Log("Need Key");
            }
        }
    }

    void UnlockDoor()
    {
        if (!isDoorUnlocked)
        {
            Debug.Log("Door Opened");
            animator.SetTrigger("UnlockDoor"); // Trigger the animation to open the door
            isDoorUnlocked = true; // Mark the door as unlocked
        }
    }

    private void DestroyKey(FirstPersonControls firstPersonControls)
    {
        // Check if the player is holding a key object
        if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.CompareTag("Key"))
        {
            Destroy(this.firstPersonControls.heldObject); // Destroy the key GameObject
            firstPersonControls.holdingKey = false; // Remove the key from the player's inventory
            Debug.Log("Key has been destroyed.");
        }
    }
}