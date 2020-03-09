using UnityEngine;

public class Alert : MonoBehaviour
{
    /// <summary>
    /// The amount of time that should elapse between each alert, in seconds.
    /// </summary>
    public float AlertCooldown = 5.0f;

    public AlertSeverity severity;

    private float sinceAlert;


    [System.Serializable]
    public class AlertZoneEnteredEvent : UnityEngine.Events.UnityEvent<Collider, string, AlertSeverity> { }
    public AlertZoneEnteredEvent OnZoneEntered;


    private void Start()
    {
        sinceAlert = AlertCooldown;
    }

    private void Update()
    {
        if (sinceAlert < AlertCooldown) sinceAlert += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (sinceAlert < AlertCooldown)
            return;
        OnZoneEntered.Invoke(other, gameObject.tag, severity);
        sinceAlert = 0;
    }
}

public enum AlertSeverity
{
    Low,
    High
}
