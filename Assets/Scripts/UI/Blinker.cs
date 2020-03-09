using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    Image target;

    bool blinking;

    public float LowAlertBlinkingDuration = 2.0f;
    public float HighAlertBlinkingDuration = 5.0f;

    private float BlinkingDuration
    {
        get => lowAlert ? LowAlertBlinkingDuration : HighAlertBlinkingDuration;
    }

    private float BlinkingSpeed
    {
        get => lowAlert ? LowAlertBlinkingSpeed : HighAlertBlinkingSpeed;
    }

    public float LowAlertBlinkingSpeed = 2.0f;
    public float HighAlertBlinkingSpeed = 5.0f;
    public bool StartHidden = true;

    private bool lowAlert = true;

    float blinkingTime = 0.0f;

    private void Start()
    {
        target = gameObject.GetComponent<Image>();
        if (StartHidden)
            target.color = new Color(target.color.r, target.color.g, target.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (blinking)
        {
            target.color = new Color(
                target.color.r,
                target.color.g,
                target.color.b,
                Mathf.Abs(Mathf.Sin(blinkingTime * BlinkingSpeed))
            );
            blinkingTime += Time.deltaTime;
        }
    }

    public void StartBlinking(AlertSeverity severity)
    {
        blinking = true;
        lowAlert = severity == AlertSeverity.Low;
        Invoke("StopBlinking", BlinkingDuration);
    }

    void StopBlinking()
    {
        blinking = false;
        blinkingTime = 0;
        target.color = new Color(target.color.r, target.color.g, target.color.b, 0);
    }
}
