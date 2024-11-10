using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    private bool doorOpen = false;
    private Animator animator;

    [SerializeField] private string openAnimationName = "SDSliding";

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorlockedUI = null;
    [SerializeField] private KeyInventory KeyInventory = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>(); 
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void playAnimation()
    {
        if (KeyInventory.hasKey)
        {
            if(!doorOpen && !pauseInteraction)
            {
                animator.Play(openAnimationName,0,0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction()); 

            }
            
        }
        else
        {
            StartCoroutine(showDoorLockedUI());

        }

        IEnumerator showDoorLockedUI()
        {
            showDoorlockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorlockedUI.SetActive(false);
        }
    }




}