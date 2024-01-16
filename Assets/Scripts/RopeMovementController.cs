using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovementController : MonoBehaviour
{
    [SerializeField] private DrawingController _drawingController;
    [SerializeField] private FinishController _finishController;

    private Vector3[] _allCoordinates;
    private int _currentIndex = 1;
    private float _speed = 2.5f;

    private void Awake()
    {
        _drawingController.OnDrawingFinished += GetAllCoordinates;
    }

    private void GetAllCoordinates(Vector3[] allCoordinates)
    {
        _allCoordinates = allCoordinates;
    }

    private void SetNextPoint()
    {
        _currentIndex++;
    }

    public void StopMovement()
    {
        _allCoordinates = null;
    }

    private void Update()
    {
        if (_allCoordinates == null)
        {
            return;
        }
        var startPosition = transform.position;
        if (_currentIndex>=_allCoordinates.Length)
        {
            return;
        }
        var nextPosition = _allCoordinates[_currentIndex];
        transform.position = Vector3.MoveTowards(startPosition,nextPosition,Time.deltaTime*_speed);
        if (transform.position == nextPosition)
        {
            SetNextPoint();
        }
    }

    private void OnDestroy()
    {
        _drawingController.OnDrawingFinished -= GetAllCoordinates;
    }
}