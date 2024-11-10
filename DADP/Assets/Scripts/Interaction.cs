using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Interaction : MonoBehaviour
{
    public float interactionDistance;
    //public GameObject interactionText;
    public LayerMask interactionLayers;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayers))
        {
            if (hit.collider.gameObject.GetComponent<Letter>())
            {
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<Letter>().openCloseLetter();

                }
            }
            else
            {
                //interactionText.SetActive(false);

            }
            
        }
        else
        {
            //interactionText.SetActive(false);

        }
    }
}
