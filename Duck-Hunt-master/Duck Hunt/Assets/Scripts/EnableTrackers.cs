using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTrackers : MonoBehaviour
{
    public GameObject handTracker;
    public GameObject elbowTracker;

    // Start is called before the first frame update
    void Start()
    {
        handTracker.SetActive(true);
        elbowTracker.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
