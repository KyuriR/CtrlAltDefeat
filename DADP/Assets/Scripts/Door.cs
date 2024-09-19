using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public Animator animator;
    private bool isDoorOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isDoorOpen == false)
            {
                animator.SetTrigger("AnimateDoor"); //open the door
                Debug.Log("open door");
            }
            else
            {
                animator.SetTrigger("AnimateDoor"); //close the door
            }
        }
    }
}

