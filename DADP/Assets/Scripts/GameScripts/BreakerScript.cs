using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerScript : MonoBehaviour
{
    public GameObject[] Lights;

    private bool inRange = false;
    public bool isPowerOn;

    private FirstPersonControls firstPersonControls;

    void Start()
    {
        StartCoroutine(TurnOnPowerRoutine());
        foreach (GameObject light in Lights)
        {
            light.SetActive(true);
        }
    }
    
    IEnumerator TurnOnPowerRoutine()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(true);
            yield return new WaitForSeconds(0.1f); // Small delay to help with timing
        }
        Debug.Log("All lights turned on.");
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
        if (Input.GetKeyDown(KeyCode.F) && inRange)
        {
            isPowerOn = true;
            DestroyFuse(firstPersonControls);
            
        }

        if (isPowerOn)
        {
            /*foreach (GameObject light in Lights)
            {
                light.SetActive(true);
            }*/
            StartCoroutine(TurnOnPowerRoutine());
        }

        if (!isPowerOn)
        {
            foreach (GameObject light in Lights)
            {
                light.SetActive(false);
            }
        }
    }
    
    /*public void TurnOnPower()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(true);
        }
    }*/

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
            Destroy(this.firstPersonControls.heldObject);
            firstPersonControls.holdingFuse = false;
            Debug.Log("Fuse destroyed");
        }
    }
}

