using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeStacker : MonoBehaviour
{
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
            if (currectCakePropOnTop == null)
            {
               
                other.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
                other.transform.parent = transform;
                currectCakePropOnTop = other.transform;
                cakeStack.Add(currectCakePropOnTop);
            }
            if (currectCakePropOnTop != null)
            {

                other.transform.position = currectCakePropOnTop.Find("PivotTop").transform.position+new Vector3(0,other.transform.GetComponent<BoxCollider>().size.y/2,0);



                other.transform.parent = currectCakePropOnTop.transform;
                currectCakePropOnTop = other.transform;
                cakeStack.Add(currectCakePropOnTop);
            }

        }
    }
}
