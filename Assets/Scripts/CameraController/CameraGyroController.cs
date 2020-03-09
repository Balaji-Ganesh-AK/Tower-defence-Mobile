using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyroController : MonoBehaviour
{
    // STATE
    private float _initialYAngle = 0f;
    private float _appliedGyroYAngle = 0f;
    private float _calibrationYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;
    private Camera camera;

    // SETTINGS
    [SerializeField] private float _smoothing = 0.1f;

    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        camera = GetComponent<Camera>();
        _initialYAngle = camera.transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        // Wait until gyro is active, then calibrate to reset starting rotation.
        yield return new WaitForSeconds(1);

        StartCoroutine(CalibrateYAngle());
    }

    private void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();
        Debug.Log("camera"+ camera.transform.rotation);
        //camera.transform.rotation = Quaternion.Slerp(new Quaternion(Mathf.Clamp (camera.transform.rotation.x, -0.3f,0.3f), Mathf.Clamp(camera.transform.rotation.y, -0.3f, 0.3f),camera.transform.rotation.z, camera.transform.rotation.w), _rawGyroRotation.rotation, _smoothing);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, new Quaternion(Mathf.Clamp(_rawGyroRotation.rotation.x, -0.19f, 0.19f), Mathf.Clamp(_rawGyroRotation.rotation.y, -0.3f, 0.3f), _rawGyroRotation.rotation.z, _rawGyroRotation.rotation.w), _smoothing);

    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYAngle = _appliedGyroYAngle - _initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        _rawGyroRotation.Rotate(90f, 180f, 180f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }

    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }
}