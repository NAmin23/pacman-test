using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class handTracker : MonoBehaviour
{
  private string path; //Path of file
  private float time; //Stores total playtime
  private string coordinates;
  private int i = 0;

  private int doOnce;

  public void CreateText()
  {

    path = Application.dataPath + "/" + "handTracker" + i + ".txt";

    if (!File.Exists(path)) //Create new file if it doesn't exist
    {
      File.WriteAllText(path, "time\t" + "x\t" + "y\t" + "z\t" + "\n");
    }
    else //If it does exist, create a new title for the data path
    {
      i++;
      CreateText();
    }
  }

  private void Awake()
  {
    CreateText();
    coordinates = "";
    time = .0f;
  }

  private void Update()
  {
    time += Time.deltaTime; //Increment time

    if (Input.GetKeyDown("space"))
    {
      doOnce++;
    }

      if (doOnce == 1)
    {
      coordinates = time.ToString() + "\t" + transform.position.x.ToString() + "\t" + transform.position.y.ToString() + "\t" + transform.position.z.ToString() + "\n";
      File.AppendAllText(path, coordinates);
    }
  }
}
