using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerScript : MonoBehaviour
{

    public GameObject[] Lights;
    public bool isPowerOn;
    private bool inRange;
    
    // Start is called before the first frame update    
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    public void TurnOffPower()
    {
        foreach (GameObject lights in Lights)
        {
            lights.SetActive(false);
        }

        //isPowerOn = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange)
        {
            //isPowerOn = true;
            foreach (GameObject lights in Lights)
            {
                lights.SetActive(true);
            }
        }

        /*if (isPowerOn)
        {
            foreach (GameObject lights in Lights)
            {
                lights.SetActive(true);
            }
        }
        
        if (!isPowerOn)
        {
            foreach (GameObject lights in Lights)
            {
                lights.SetActive(false);
            }
        }*/
    }
}
