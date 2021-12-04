using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;

    public int timeCost;
    public GameObject[] snapPoints;
    private float snapSensitivity = .75f;
    private Vector3 initialPosition;
    private bool snapped;


    public delegate void PartChanged(int timeChange);
    public static event PartChanged OnPartChanged;

    private void Awake()
    {
        _cam = Camera.main;
        initialPosition = transform.position;
        snapped = false;
    }

    private void OnMouseDown()
    {
        _dragOffset = transform.position - getMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = getMousePos() + _dragOffset;
        for (int i = 0; i < snapPoints.Length; i++)
        {
            if (Vector3.Distance(snapPoints[i].transform.position, transform.position) < snapSensitivity)
            {
                transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
            }
        }
    }

    private void OnMouseUp()
    {
        DropPart();
    }

    Vector3 getMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void DropPart()
    {
        bool alreadySnapped = snapped;


        for(int i = 0; i < snapPoints.Length; i++)
        {
            if ((Vector3.Distance(snapPoints[i].transform.position, transform.position) < snapSensitivity) && !partWouldExceedAlottedTime(timeCost))
            {

                transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
                snapped = true;
                if (OnPartChanged != null)
                {
                    OnPartChanged(timeCost);
                }
            } else
            {
                snapped = false; 
            }

        }
        if (snapped == false)
        {
            transform.position = initialPosition;
            // only deduct the part time cost if it was already snapped and is now not snapped
            if (OnPartChanged != null && alreadySnapped)
            {
                OnPartChanged(-1*timeCost);
            }
        }
    }

    bool partWouldExceedAlottedTime(int timeCost)
    {
        float timeIfPartWasAdded = timeDialScript.currentTime + timeCost;
        return timeIfPartWasAdded < 0f;
    }

}
