using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public NewInput newInput;
    public static EventHandler OnPlayerTouchScreen;
    public static EventHandler OnPlayerNotTouchScreen;
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
        OnPlayerNotTouchScreen.Invoke(this, EventArgs.Empty);

    }

    private void OnPlayerTouch(InputAction.CallbackContext obj)
    {
   
        Debug.Log("Touching!!");
        OnPlayerTouchScreen.Invoke(this, EventArgs.Empty);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
