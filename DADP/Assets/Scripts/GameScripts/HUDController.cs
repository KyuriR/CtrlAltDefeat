using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{

    public GameObject Flashlight;
    public GameObject FlashlightON;
    public GameObject FlashlightOFF;
    
    void Start()
    {
        FlashlightON.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Flashlight.activeInHierarchy)
        {
            FlashlightON.SetActive(true);
            FlashlightOFF.SetActive(false);
        }
        else
        {
            FlashlightON.SetActive(false);
            FlashlightOFF.SetActive(true);
        }
    }
}
