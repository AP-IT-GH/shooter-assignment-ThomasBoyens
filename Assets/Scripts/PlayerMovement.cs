using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private InputActionAsset _inputActionAsset;

    private InputAction _horizontalAction;

    private float _horizontal = 0f;

    private void Awake()
    {
        var playerActionMap = _inputActionAsset.FindActionMap("Player");

        _horizontalAction = playerActionMap.FindAction("Horizontal");
        _horizontalAction.canceled += OnHorizontalCanceled;
    }

    private void Update()
    {
        var xOffset = _horizontal * moveSpeed * Time.deltaTime;
        var newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -15, 15);
        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void OnHorizontal(InputValue value)
    {
        var data = value.Get<float>();
        
        _horizontal = data;
    }
    
    private void OnHorizontalCanceled(InputAction.CallbackContext context)
    {
        var data = context.ReadValue<float>();
        
        _horizontal = data;
    }
}
