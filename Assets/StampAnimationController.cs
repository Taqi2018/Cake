using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampAnimationController : MonoBehaviour
{
    Animator stampAnimator;
    // Start is called before the first frame update
    void Start()
    {
        stampAnimator = transform.gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (CakeController.instance.isSmashed)
        {
            stampAnimator.SetBool("isCakePresent", CakeController.instance.isSmashed);
            CakeController.instance.isSmashed = false;
        }
        
    }
}
