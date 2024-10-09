using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Camera Cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask Mask;

    private PlayerUI playerUI;
    private FirstPersonControls firstPersonControls;
    void Start()
    {
        Cam = GetComponent<FirstPersonControls>().Cam;
        playerUI = GetComponent<PlayerUI>();
        firstPersonControls = GetComponent<FirstPersonControls>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(String.Empty);
        
        Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, Mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                
                /*if (firstPersonControls.playerActions.PickUp.triggered)
                {
                    interactable.BaseInteract();               If yall see this will fix this later
                }*/
            }
        }
    }
}
