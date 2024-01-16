using System;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField] private BoxController _boxController;
    [SerializeField] private RopeMovementController _ropeMovementController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rope"))
        {
            _boxController.DropDown(transform.position);
            _ropeMovementController.StopMovement();
        }
    }
}
