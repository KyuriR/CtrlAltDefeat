using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    private FirstPersonControls firstPersonControls;

    private bool isUnlocked = false;
    public GameObject wood;
    public GameObject lockObject; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firstPersonControls = other.GetComponent<FirstPersonControls>();

            if (firstPersonControls != null && firstPersonControls.holdingKey)
            {
                Destroy(gameObject);
                //DestroyKey(firstPersonControls);
                Debug.Log("Escaped");
                wood.SetActive(false);
                lockObject.SetActive(false);
            }
            else
            {
                Debug.Log("Need Key");
            }
        }
    }
    
    
}
