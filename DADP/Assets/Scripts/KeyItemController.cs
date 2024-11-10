using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool frontDoor = false;
    [SerializeField] private bool securityDoor= false;
    [SerializeField] private bool key = false;
    [SerializeField] private bool securityKey = false;

    [SerializeField] private KeyInventory keyInventory = null;

    private SlidingDoor doorObject;


    // Start is called before the first frame update
   private void Start()
    {
     if (frontDoor)
        {
            doorObject = GetComponent<SlidingDoor>();
        }   
    }

    public void ObjectInteraction()
    {
        if (frontDoor )
        {
            doorObject.playAnimation();

        }
        else if (key)
        {
            keyInventory.hasKey = true;
            gameObject.SetActive(false);
        }
    }
}
