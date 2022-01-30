using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicMove : MonoBehaviour
{
  public GameObject tracker;
  private Vector3 startPos;
  private Vector3 trackerPos;

    // Start is called before the first frame update
    void Start()
    {
      startPos = transform.position;
      trackerPos = tracker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = tracker.transform.position * 3 - trackerPos + startPos;
  }
}
