using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public NewInput newInput;
    public static EventHandler <OnPlayerTouchEventArgs>OnPlayerTouchEnter;

    public class OnPlayerTouchEventArgs
    {
        public Vector2 position;
    }
    public static EventHandler<OnPlayerTouchEventArgs> OnPlayerTouchExit;
    public bool playerTouching;

    
    public static PlayerInput instance;
    // Start is called before the first frame update

    void Awake()
    {
        newInput = new NewInput();
    }
    void Start()
    {
        instance = this;
        newInput.Enable();

        newInput.Move.Touch.started += OnPlayerTouch;
        
  
       
        newInput.Move.Touch.canceled += OnPlayerNotTouch;


    }


    private void OnPlayerNotTouch(InputAction.CallbackContext obj)
    {

            Debug.Log("End!");
            OnPlayerTouchExit.Invoke(this, new OnPlayerTouchEventArgs { position = newInput.Move.Position.ReadValue<Vector2>() });
 
    }

    private void OnPlayerTouch(InputAction.CallbackContext obj)
    {


            Debug.Log("Touching!!");
            OnPlayerTouchEnter.Invoke(this, new OnPlayerTouchEventArgs { position = newInput.Move.Position.ReadValue<Vector2>() });
 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
