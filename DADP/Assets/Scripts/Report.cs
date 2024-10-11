using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    public GameObject ReportUI;
    bool Pickup;

    public void openCloseReport()
    {
        Pickup = !Pickup;
        if (Pickup == false)
        {
            ReportUI.SetActive(false);
        }
        if (Pickup == true)
        {
            ReportUI.SetActive(true);
        }

    }
}