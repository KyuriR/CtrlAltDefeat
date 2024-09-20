using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{

    public bool isFlickering;
    public float timeDelay;
    
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickerTimer());
        }
        
    }

    IEnumerator FlickerTimer()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
