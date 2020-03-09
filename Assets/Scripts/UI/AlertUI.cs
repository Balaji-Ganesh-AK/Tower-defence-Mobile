using System.Collections.Generic;
using UnityEngine;

public class AlertUI : MonoBehaviour
{
    private Dictionary<string, GameObject> towerAlerts = new Dictionary<string, GameObject>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            towerAlerts.Add(child.tag, child.gameObject);
            // Be sure to hide everything, I guess
            //child.gameObject.SetActive(false);
        }
    }

    public void Alert(Collider collider, string tag, AlertSeverity severity)
    {
        if (!collider.gameObject.GetComponentInParent<Agent>()) return;
        towerAlerts[tag].GetComponent<Blinker>()?.StartBlinking(severity);
    }
}
