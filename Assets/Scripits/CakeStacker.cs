using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeStacker : MonoBehaviour
{

    [SerializeField] Transform cakePlate;


    // Start is called before the first frame update
    List<Transform> cakeStack;
    Transform currectCakePropOnTop;
    
    void Start()
    {
        cakeStack = new List<Transform>();
        currectCakePropOnTop = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cake")
        {
            Transform objectToPick = null; 
            if (other.name == "Collider")
            {
                objectToPick =other.transform.parent;
            }
            else
            {
                objectToPick = other.transform;

            }
            if (currectCakePropOnTop == null)
            {
                Debug.Log("First..");

                objectToPick.position = new Vector3(cakePlate.position.x, cakePlate.position.y, cakePlate.position.z);
                objectToPick.parent = transform;
                currectCakePropOnTop = objectToPick.transform;
                cakeStack.Add(currectCakePropOnTop);
            }
            else if (currectCakePropOnTop != null)
            {

                Debug.Log(other.transform.name);

                objectToPick.position = currectCakePropOnTop.Find("TopPivot").transform.position + new Vector3(0, other.transform.GetComponent<BoxCollider>().size.y / 2, 0);



                objectToPick.parent = transform;
                currectCakePropOnTop = objectToPick.transform;
                cakeStack.Add(currectCakePropOnTop);
            }

        }
    }
}
