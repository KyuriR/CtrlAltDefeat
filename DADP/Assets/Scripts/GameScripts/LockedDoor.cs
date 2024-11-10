using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private bool isDoorUnlocked = false;
    private FirstPersonControls firstPersonControls;
    private BreakerScript breakerScript;
    public Animator animator;

    private void Start()
    {
        breakerScript = GameObject.FindGameObjectWithTag("Breaker").GetComponent<BreakerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firstPersonControls = other.GetComponent<FirstPersonControls>();

            if (firstPersonControls != null && firstPersonControls.holdingKeycard)
            {
                UnlockDoor();
                DestroyKey(firstPersonControls);
                breakerScript.TurnOffPower();
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
        if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.CompareTag("Keycard"))
        {
            Destroy(this.firstPersonControls.heldObject); // Destroy the key GameObject
            firstPersonControls.holdingKeycard = false; // Remove the key from the player's inventory
            Debug.Log("Key has been destroyed.");
        }
    }
}