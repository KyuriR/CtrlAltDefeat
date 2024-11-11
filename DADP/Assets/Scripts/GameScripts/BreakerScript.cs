using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;


public class BreakerScript : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject breakerSwitch;
    public GameObject tvScreens;
    public GameObject powerOntext;

    private bool inRange = false;
    public bool isPowerOn;

    private FirstPersonControls firstPersonControls;

    void Start()
    {
        tvScreens.SetActive(false);
        breakerSwitch.SetActive(false);
        powerOntext.SetActive(false); 
        foreach (GameObject light in Lights)
        {
            light.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firstPersonControls = other.GetComponent<FirstPersonControls>();
            if (firstPersonControls != null && firstPersonControls.holdingFuse)
            {
                inRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void Update()
    {
        if (inRange && firstPersonControls != null && firstPersonControls.holdingFuse)
        {
            isPowerOn = true;
            DestroyFuse(firstPersonControls);
            
            breakerSwitch.SetActive(true);
            tvScreens.SetActive(true);
        }

        if (isPowerOn)
        {
            StartCoroutine(TurnOnPowerRoutine());
            

            /*if (powerOntext != null)
            {
                StartCoroutine(DisplayPowerOnText());
            }*/
        }
        else
        {
            TurnOffPower();
        }
    }

    IEnumerator TurnOnPowerRoutine()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        
        
    }

    IEnumerator DisplayPowerOnText()
    {
        if (powerOntext != null)
        {
            powerOntext.SetActive(true);
            yield return new WaitForSeconds(10f); 

            if (powerOntext != null) 
            {
                Destroy(powerOntext); 
            }
        }
    }

    public void TurnOffPower()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(false);
        }

        isPowerOn = false;
    }

    private void DestroyFuse(FirstPersonControls firstPersonControls)
    {
        if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.CompareTag("Fuse"))
        {
            Destroy(firstPersonControls.heldObject);
            firstPersonControls.holdingFuse = false;
            Debug.Log("Fuse destroyed");
        }
    }
}