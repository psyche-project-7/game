using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;

    public GameObject[] snapPoints;
    private float snapSensitivity = 0.5f;
    private Vector3 initialPosition;
    private void Awake()
    {
        _cam = Camera.main;
        initialPosition = transform.position;
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
        DropObject();
    }

    Vector3 getMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void DropObject()
    {

        bool snapped = false;
        for(int i =0; i< snapPoints.Length; i++)
        {
            if (Vector3.Distance(snapPoints[i].transform.position, transform.position) < snapSensitivity)
            {
                transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
                snapped = true;
            }
        }
        if (snapped == false)
        {
            transform.position = initialPosition;
        }
    }

}
