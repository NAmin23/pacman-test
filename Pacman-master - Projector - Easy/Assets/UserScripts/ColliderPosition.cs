using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPosition : MonoBehaviour
{
   public GameObject tracker;
   public Vector3 adjustment;
   int counter = 0;

  // Start is called before the first frame update
  void Start()
   {
     transform.position = tracker.transform.position + adjustment;
   }

    // Update is called once per frame
   void Update()
   {
    transform.position = tracker.transform.position + adjustment;
    /*
     if(Time.deltaTime == 0)
     {
       transform.position = tracker.transform.position + adjustment;
       counter = 0;
     }
     if(Time.deltaTime != 0 && counter < 180) //Update for first 3 seconds
     {
       transform.position = tracker.transform.position + adjustment;
     }
     counter++;
     */
  }
}
