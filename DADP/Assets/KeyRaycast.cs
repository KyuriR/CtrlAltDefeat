using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyRaycast : MonoBehaviour
{
    [SerializeField] private int raylength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private KeyItemController raycastedObject;
    [SerializeField] private KeyCode openDoorkey = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;
    private string interactableTag = "InteractableObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName)| layerMaskInteract.value;
        if (Physics.Raycast(transform.position, fwd, out hit, raylength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    CrosshairChange(true);


                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorkey))
                {
                    raycastedObject.ObjectInteraction();

                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange (false);
                doOnce = false; 

            }
        }

    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;

        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }

}
