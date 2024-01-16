using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrawingController : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private float _depth = 13f;
    private Vector3[] _allCoordinates;
    public Action<Vector3[]> OnDrawingFinished;
    private bool _isDrawing = true;

    private void Update()
    {
        if (_isDrawing == false)
        {
          return;  
        }
        if (Input.GetMouseButton(0))
        {
            var mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,_depth);
            var pointDrawing = Camera.main.ScreenToWorldPoint(mousePosition);
            var lastPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
            if (Vector3.Distance(lastPosition,pointDrawing)<0.1f)
            {
                return;
            }
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount-1,pointDrawing);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
            _allCoordinates = new Vector3[_lineRenderer.positionCount];
            _lineRenderer.GetPositions(_allCoordinates);
            OnDrawingFinished?.Invoke(_allCoordinates);
        }
    }
    
}
