using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool isLeftWire;
    public Color wireColor;
    private Image _image;
    private LineRenderer _lineRender;
    private Canvas _canvas;
    private bool _isDragStarted = false;
    private Camera _cam;
    private Vector3 initialPosition;
    private WireTask _wireTask;
    public bool isConnected = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRender = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _cam = Camera.main;
        initialPosition = transform.position;
        _wireTask = GetComponentInParent<WireTask>();

    }

    private void Update()
    {
        if(_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _cam,
                out movePos);

            _lineRender.SetPosition(0, initialPosition);
            _lineRender.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            
            if (!isConnected) {
                _lineRender.SetPosition(0, Vector3.zero);
                _lineRender.SetPosition(1, Vector3.zero);
            }
            
        }
        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _cam);

        if (isHovered)
        {
            _wireTask.CurrentHoveredWire = this;
        }
        

    }

    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRender.startColor = color;
        _lineRender.endColor = color;
        wireColor = color;
    }

  

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isLeftWire && !isConnected)
        {
            _isDragStarted = true;
            _wireTask.CurrentDraggedwire = this;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wireTask.CurrentHoveredWire != null)
        {
            if (_wireTask.CurrentHoveredWire.wireColor == wireColor && !_wireTask.CurrentHoveredWire.isLeftWire)
            {
                isConnected = true;
                int count = 0;
                for (int i =0; i< _wireTask._leftWires.Count; i++)
                {
                    if (_wireTask._leftWires[i].isConnected)
                    {
                        count++;
                    }
                }
                if (count == _wireTask._leftWires.Count)
                {
                    _wireTask.gameComplete = true;
                }
                
            }
        }
        _isDragStarted = false;
        _wireTask.CurrentDraggedwire = null;
    }
}
