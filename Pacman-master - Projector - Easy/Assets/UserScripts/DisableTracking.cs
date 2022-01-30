using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DisableTracking : MonoBehaviour
{
  // Start is called before the first frame update
  public Vector3 startPos;
  public Quaternion startRot;

    void Start()
    {
    UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    startPos = transform.position;
    startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = -UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
      transform.rotation = Quaternion.Inverse(UnityEngine.XR.InputTracking.GetLocalRotation((UnityEngine.XR.XRNode.CenterEye)));
    transform.position = startPos;
    transform.rotation = startRot;
    }
}
