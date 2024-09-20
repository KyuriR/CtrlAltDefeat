using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public Animator animator;
    private bool isDoorOpen = false;
    private bool isPlayerInRange;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isDoorOpen == false)
            {
                OpenStairDoor();
            }
            else
            {
                CloseStairDoor();
            }
        }
    }

    void OpenStairDoor()
    {
        animator.SetTrigger("AnimateDoor"); //open the door
        Debug.Log("open door");
    }

    void CloseStairDoor()
    {
        animator.SetTrigger("AnimateDoor"); //close the door
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
}

