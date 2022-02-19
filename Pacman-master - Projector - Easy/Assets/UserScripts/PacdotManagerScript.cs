using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacdotManagerScript : MonoBehaviour
{
    public GameObject innerMaze;
    // Placed on EventSystem
    void Start()
    {
        if (innerMaze.activeSelf)
        {
            Debug.Log("Inner Maze Child Count: " + innerMaze.transform.childCount);

            int i = 0;

            // Array to hold all child obj
            GameObject[] allChildren = new GameObject[innerMaze.transform.childCount];

            // Find each child object and store into array
            foreach (Transform child in innerMaze.transform)
            {
                allChildren[i] = child.gameObject;
                i++;
            }

            // Rename children
             foreach (GameObject child in allChildren)
             {
                child.name = "pacdot";
             }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
