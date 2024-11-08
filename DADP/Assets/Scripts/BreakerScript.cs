using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class BreakerScript : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject AppearSwitch;
    public SwitchPickup PickUpSwitch;
    public GameObject switchText;

    private bool inRange = false;
    private bool isPowerOn = false;

    void Start()
    {
    //    if (AppearSwitch != null)
    //    {
    //        AppearSwitch.SetActive(false);
    //    }

        //switchText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            UpdatePrompt();
            Debug.Log("Player in range to place the PickUpSwitch");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            switchText.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && inRange && !isPowerOn && PickUpSwitch.IsPickedUp())
        {
            AppearSwitch.SetActive(true);
            isPowerOn = true;
            TurnOnPower();
            switchText.gameObject.SetActive(false);
            Debug.Log("PickUpSwitch placed in box and power turned on");
        }
    }

    void UpdatePrompt()
    {
        if (inRange && PickUpSwitch.IsPickedUp() && !isPowerOn)
        {
            switchText.gameObject.SetActive(true);
        }
        else
        {
            switchText.gameObject.SetActive(false);
        }
    }

    public void TurnOnPower()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(true);
        }
    }

    public void TurnOffPower()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(false);
        }
    }
}