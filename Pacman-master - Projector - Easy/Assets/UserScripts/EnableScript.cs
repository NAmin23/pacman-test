using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour
{
  public GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
      tracker.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    tracker.SetActive(true);
  }
}
