using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float x_position;
    public float maxSpeed = 10f; // Set your desired maximum speed here

    public float targetX,newX;
    private bool isPlayerTouching;
    



    // Start is called before the first frame update
    void Start()
    {
        x_position = 0;
        PlayerInput.OnPlayerTouchScreen += OnEventPlayerTouch;
        PlayerInput.OnPlayerNotTouchScreen += OnEventPlayerNotTouch;
        
        

        
    }

    private void OnEventPlayerNotTouch(object sender, EventArgs e)
    {
        isPlayerTouching = false;

    }

    private void OnEventPlayerTouch(object sender, EventArgs e)
    {
        isPlayerTouching = true;
    }

    // Update is called once per frame

    void Update()
    {
        if (isPlayerTouching)
        {
            Vector3 mousePosition = PlayerInput.instance.newInput.Move.Position.ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                targetX = hitInfo.point.x;
                float currentX = transform.position.x;

                // Smoothly move towards the target position
                newX = Mathf.MoveTowards(currentX, targetX, speed * Time.deltaTime);
                transform.position = new Vector3(newX
                    
                    
                    
                    
                    
       , transform.position.y, transform.position.z);
            }

            // Update the ball speed
            speed = Mathf.Clamp(speed, 0f, maxSpeed);

       
        }
        // Move the ball in the z-axis with the limited speed
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
    }

}
