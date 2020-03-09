using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion initialRotation;
    public GameObject camera;
    void Start()
    {

        initialRotation = camera.transform.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
        initialRotation = camera.transform.rotation;
    }
    public Quaternion getInitialRotation { get { return initialRotation; } }
}
