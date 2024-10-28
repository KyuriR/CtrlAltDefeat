using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DragDrop : MonoBehaviour

{
    public GameObject ObjectToDrag;
    public GameObject ObjectDragToPos;
    public float DropDistance;
    public bool IsLocked;
    Vector3 ObjectInitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        ObjectInitialPosition = ObjectToDrag.transform.position;
    }

    // Update is called once per frame
    public void DragObject()
    {
        if (IsLocked)
        {
         ObjectToDrag.transform.position = Input.mousePosition;

        }

    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(ObjectToDrag.transform.position, ObjectDragToPos.transform.position);
        if (Distance < DropDistance ) 
        {
            IsLocked = true;
            ObjectToDrag.transform.position = ObjectDragToPos.transform.position;

        }
        else
        {
            ObjectToDrag.transform.position = ObjectInitialPosition;
        }
    }
}
