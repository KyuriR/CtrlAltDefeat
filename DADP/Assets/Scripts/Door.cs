using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door: MonoBehaviour
{
    public Animator animator;
    private bool isDoorOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("AnimateDoor");
            Debug.Log("open door");
        }
    }

    //void OpenDoor()
    //{
    //    animator.SetTrigger("Open");
    //    isDoorOpen = true;
    //}

    //void CloseDoor()
    //{
    //    animator.SetTrigger("Close");
    //    isDoorOpen = false;
    //}
}