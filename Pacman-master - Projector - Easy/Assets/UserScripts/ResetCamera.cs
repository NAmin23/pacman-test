using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    public Vector3 cameraPosition;
    public Quaternion cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
    UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = cameraPosition;
      transform.rotation = cameraRotation;
    }
}
