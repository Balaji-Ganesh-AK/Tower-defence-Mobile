using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public TowerSwap towerSwap;
    public Camera_gyro cameraController;
    Ray raycast;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame

    void Update()
    {

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if(Camera.current)
            {
                raycast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);
            }

            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                //Shooter s = raycastHit.transform.parent.gameObject.GetComponent<Shooter>();
                //s.enabled = true;
                if (raycastHit.transform.parent.gameObject.tag == "Tower" || raycastHit.transform.parent.gameObject.tag == "Tower1" || raycastHit.transform.parent.gameObject.tag == "Tower2")
                {
                    towerSwap.SwapTower(raycastHit.transform.parent.gameObject.transform.localPosition);
                    
                    cameraController.initialTowerRotation= raycastHit.transform.parent.gameObject.transform.GetComponent<TowerManager>().getInitialRotation;
                    cameraController.isBackToMenu = false;
                    Transform turrent = raycastHit.transform.parent.Find("Turret Low");
                    cameraController.towerTransform = turrent;
                    cameraController.tagName = raycastHit.transform.parent.tag;
                    // Debug.Log(turrent);

                }
                else if (raycastHit.transform.parent.gameObject.tag == "Tower3")
                {
                    towerSwap.SwapTowerDown(raycastHit.transform.parent.gameObject.transform.localPosition);
                    cameraController.initialTowerRotation = raycastHit.transform.parent.gameObject.transform.GetComponent<TowerManager>().getInitialRotation;
                    cameraController.isBackToMenu = false;
                    Transform turrent = raycastHit.transform.parent.Find("Turret Low");
                    cameraController.towerTransform = turrent;
                    cameraController.tagName = raycastHit.transform.parent.tag;
                }

            }
        }

    }

}

