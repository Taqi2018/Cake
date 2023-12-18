using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CakeStacker : MonoBehaviour
{

     [SerializeField] Transform cakePlate;
     [SerializeField] GameObject GameWinCanvas;
     [SerializeField] GameObject GameLoseCanvas;

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
                    objectToPick = other.transform.parent;
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

          if (other.tag == "End")
          {
               if (SceneManager.GetActiveScene().name == "Level1")
               {
                    if (cakeStack[0].gameObject.name.Contains("Brown") && cakeStack[1].gameObject.name.Contains("Brown") && cakeStack[2].gameObject.name.Contains("Brown"))
                    {
                         GameWinCanvas.SetActive(true);
                    }
                    else
                    {
                         GameLoseCanvas.SetActive(true);
                    }
               }

               else if (SceneManager.GetActiveScene().name == "Level2")
               {
                    if (cakeStack[0].gameObject.name.Contains("Pink") && cakeStack[1].gameObject.name.Contains("Pink") && cakeStack[2].gameObject.name.Contains("Pink"))
                    {
                         GameWinCanvas.SetActive(true);
                    }
                    else
                    {
                         GameLoseCanvas.SetActive(true);
                    }
               }
               
               
          }
     }
}
