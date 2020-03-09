using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSwap : MonoBehaviour
{
  
    public Camera_gyro cameraController;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    public void SwapTower(Vector3 selectedTower)
    {
        Vector3 offset = new Vector3(selectedTower.x,selectedTower.y /*+ 7f*/,selectedTower.z);

        cameraController.isMoveCamera = true;
       cameraController.movePosition = offset;
       
    }
    public void SwapTowerDown(Vector3 selectedTower)
    {
        Vector3 offset = new Vector3(selectedTower.x, selectedTower.y , selectedTower.z);

        cameraController.isMoveCamera = true;
        cameraController.movePosition = offset;

    }

}
