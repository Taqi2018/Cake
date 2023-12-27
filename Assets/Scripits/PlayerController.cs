using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed;

   
    public  bool isPlayerTouching;
    


    // Start is called before the first frame update
    public static PlayerController instance;
    private Vector2 startPos;
    public bool isPlayerMoving;

    void Start()
    {
        instance = this;

        PlayerInput.OnPlayerTouchEnter += OnEventPlayerTouch;
        PlayerInput.OnPlayerTouchExit += OnEventPlayerNotTouch;


    }

    private void OnEventPlayerNotTouch(object sender, PlayerInput.OnPlayerTouchEventArgs e)
    {
        isPlayerTouching = false;
        isPlayerMoving = false;
    }

    private void OnEventPlayerTouch(object sender, PlayerInput.OnPlayerTouchEventArgs e)
    {
        isPlayerTouching = true;

        startPos= e.position;
        

    }



    private void FixedUpdate()
    {

        if (isPlayerTouching)
        {

            Vector2 newPos =PlayerInput.instance.newInput.Move.Position.ReadValue<Vector2>();
            float xPos = newPos.x - startPos.x;
            if (newPos.x - startPos.x != 0)
            {
                isPlayerMoving=true;
           
            }
            transform.position += new Vector3(-xPos / 500 * Time.deltaTime, 0, -(speed * Time.deltaTime));
        }

    }



    // Unsubscribe from events to avoid MissingReferenceException
    private void OnDestroy()
    {
        PlayerInput.OnPlayerTouchEnter -= OnEventPlayerTouch;
        PlayerInput.OnPlayerTouchExit -= OnEventPlayerNotTouch;
    }


   Vector3 Convert2dTo3dWorld(Vector2 position)
    {
        Ray ray =Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray,out RaycastHit hitInfo)){
            return hitInfo.point;
        }
        return Vector3.zero;
    }
}
