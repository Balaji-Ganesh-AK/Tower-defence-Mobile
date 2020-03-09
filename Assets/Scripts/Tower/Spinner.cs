using UnityEngine;

/// <summary>
/// Causes an object to spin around. This is only meant for debugging.
/// </summary>
public class Spinner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * Mathf.Rad2Deg);
    }
}
