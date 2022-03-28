using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacdotManagerScript : MonoBehaviour
{

    // Randomizes spawning of Pacdots
    // Placed on EventSystem

    public GameObject maze;
    public int numDotsVisible = 2;
    public int seed = 1;

    private GameObject[] allChildren;
    private int totPacDots;
    private int j = 0;
    private int arrayIndex = 0;

    void Start()
    {
        if (maze.activeSelf)
        {
            Debug.Log("Maze Child Count: " + maze.transform.childCount);

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

        if (maze.transform.childCount == (totPacDots - j))
        {
            int randomNum = randomNumberGenerator();
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

    int randomNumberGenerator()
    {
        int[] randomArray = { 1, 2, 3 };
        Debug.Log("original random number is: " + randomArray[arrayIndex % 3]);
        arrayIndex++;
        return Mathf.RoundToInt(Mathf.Pow(2, randomArray[(arrayIndex % 3)])); // Minimum inclusive, max exclusive; returns 2, 4, or 8
    }
}
