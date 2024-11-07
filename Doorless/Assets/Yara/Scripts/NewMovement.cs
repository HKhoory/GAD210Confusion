using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovement : MonoBehaviour
{
    PlayerInputs playerInputs;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovingPressed;
    float rotationFactorFramed; 
    CharacterController characterController;
    float rotationFactorPerFrame = 15.0f ; 
    // Start is called before the first frame update
    void Awake()
    {
        playerInputs = new PlayerInputs();
        characterController = GetComponent<CharacterController>();

        playerInputs.CharacterControls.Move.started += onMovementInput;
        playerInputs.CharacterControls.Move.canceled += onMovementInput;
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation(); 
        characterController.Move(currentMovement * Time.fixedDeltaTime); 
        
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovingPressed = currentMovementInput.x != 0 || currentMovementInput.y !=0;
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        Quaternion currentRotation;
        Quaternion targetRotation;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z; 
        currentRotation = transform.rotation;
        if(isMovingPressed) 
        {
            
            targetRotation = Quaternion.LookRotation(positionToLookAt); 
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
            
    }
    void OnEnable()
    {
        playerInputs.CharacterControls.Enable();
    }
    
    void OnDisable()
    {
        playerInputs.CharacterControls.Disable ();
    }
}
