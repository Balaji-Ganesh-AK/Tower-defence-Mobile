using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Swipe swipeManager;
    public GameObject CameraMover;
    public float RotateSpeed; 
    public bool isTouchEnabled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isTouchEnabled == true)
        //{
        //    if (swipeManager.SwipeUp)
        //    {

        //        CameraMover.transform.Rotate(new Vector3(+RotateSpeed, 0, 0));

        //    }
        //    if (swipeManager.SwipeDown)
        //    {

        //        CameraMover.transform.Rotate(new Vector3(-RotateSpeed, 0, 0));

        //    }
        //    if (swipeManager.SwipeLeft)
        //    {

        //        CameraMover.transform.Rotate(new Vector3(0, RotateSpeed, 0));

        //    }
        //    if (swipeManager.SwipeRight)
        //    {

        //        CameraMover.transform.Rotate(new Vector3(0, -RotateSpeed, 0));

        //    }
        //    if (swipeManager.Tap)
        //    {

        //    }
        //}
        
    }
}
