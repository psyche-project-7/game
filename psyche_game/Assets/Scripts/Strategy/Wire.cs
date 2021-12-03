using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image _image;
    private LineRenderer _lineRender;
    private Canvas _canvas;
    private bool _isDragStarted = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRender = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();

    }

    private void Update()
    {
        if(_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);

            _lineRender.SetPosition(0, transform.position);
            _lineRender.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            _lineRender.SetPosition(0, Vector3.zero);
            _lineRender.SetPosition(1, Vector3.zero);
        }
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }

  

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragStarted = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragStarted = false;
    }
}
