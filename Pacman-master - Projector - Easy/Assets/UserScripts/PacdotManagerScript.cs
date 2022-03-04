using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacdotManagerScript : MonoBehaviour
{
    public GameObject maze;
    public int numDotsVisible = 5;
    public int seed = 1;

    private GameObject[] allChildren;
    private int totPacDots;
    private int j = 0;

    // Placed on EventSystem
    void Start()
    {
        if (maze.activeSelf)
        {
            Debug.Log("Inner Maze Child Count: " + maze.transform.childCount);

            int i = 0;

            // Array to hold all child obj
            allChildren = new GameObject[maze.transform.childCount];

            // Find each child object and store into array
            foreach (Transform child in maze.transform)
            {
                allChildren[i] = child.gameObject;
                allChildren[i].SetActive(false);
                if(i < numDotsVisible)
                {
                    allChildren[i].SetActive(true);
                }
                i++;
                totPacDots = i;
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

        if(maze.transform.childCount == (totPacDots - j))
        {
            Random.InitState(seed);
            int randomNum = Random.Range(1, 8);
            Debug.Log("Random Number: " + randomNum);
            for (int k = 0; k < randomNum; k++)
            {
                allChildren[numDotsVisible + j].SetActive(true);
                Debug.Log("ïterator " + j);
                k++;
                j++;
            }
            

        }
    }
}
