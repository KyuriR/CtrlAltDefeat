using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Letter : MonoBehaviour
{
    public GameObject LetterUI;
    bool Pickup;

    public void openCloseLetter()
    {
        Pickup = !Pickup;
        if (Pickup == false)
        {
            LetterUI.SetActive(false);
        }
        if (Pickup == true)
        {
            LetterUI.SetActive(true); 
        }   

    }
}
