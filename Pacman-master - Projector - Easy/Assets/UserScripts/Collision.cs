using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class Collision : PlayerController
{
  private string playerName; //Stores inputted name of player
  private string path; //Path of file
  private string dataPath; //Path  of data file
  private string keyPresses; //Stores string of movements
  private float time; //Stores total playtime
  private string coordinates;
  public GameObject inputField;
  public GameObject canvas;
  public GameObject elbowTracker; // New addition to track elbow
  private int i = 0;
  private int counter = 0;

  private Text readyText;
  public GameObject readyField;

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.name == "Left_Cube")
    {
      keyPresses = keyPresses + "Left " + time.ToString() + " seconds\n";
      Debug.Log("Left");
      _nextDir = -Vector2.right;

    }
    else if (other.gameObject.name == "Right_Cube")
    {
      keyPresses = keyPresses + "Right " + time.ToString() + " seconds\n";
      Debug.Log("Right");
      _nextDir = Vector2.right;
    }
    else if (other.gameObject.name == "Top_Cube")
    {
      keyPresses = keyPresses + "Up " + time.ToString() + " seconds\n";
      Debug.Log("Top");
      _nextDir = Vector2.up;
    }
    else if (other.gameObject.name == "Bottom_Cube")
    {
      keyPresses = keyPresses + "Down " + time.ToString() + " seconds\n";
      Debug.Log("Bottom");
      _nextDir = -Vector2.up;
    }
  }

  public void CreateText()
  {
    
    path = Application.dataPath + "/" + playerName + ".txt";
    dataPath = Application.dataPath + "/" + playerName + "_data" + i + ".txt";

    if (!File.Exists(path)) //Create new file if it doesn't exist
    {
      File.WriteAllText(path, "Player name: " + playerName + "\n");
    }

    
    if (!File.Exists(dataPath)) //Create new file if it doesn't exist
    {
      File.WriteAllText(dataPath, "x\t" + "y\t" + "time\n");
    }
    else //If it does exist, create a new title for the data path
    {
      i++;
      CreateText();
    }

    File.WriteAllText(dataPath, "x\t" + "y\t" + "time\t" + "x-coordinate\t" + "y-coordinate\t" + "z-coordinate\n");

    string content = "Login date: " + System.DateTime.Now + "\n";
    File.AppendAllText(path, content);
  }

  public void Show()
  {
    canvas.SetActive(true);
  }

  public void Hide()
  {
    canvas.SetActive(false);
  }

  private void Awake()
  {
    keyPresses = "";
    coordinates = "";
    Show();
    time = .0f;
    Time.timeScale = 0;
    readyText = readyField.GetComponent<Text>();
    //readyText.color = Color.green;
  }

  private void Update()
  {
    time += Time.deltaTime; //Increment time

    //x range is -0.7 plus/minus 1, z range is -0.2 plus/minus 0.5
    if(gameObject.transform.position.x > -1.2f && gameObject.transform.position.x < 0.1f)
    {
      if(gameObject.transform.position.z > -0.3f && gameObject.transform.position.z < 0.3f)
      {
        readyText.color = Color.green;
      }
    }
    else
    {
      readyText.color = Color.yellow;
    }

    if(Time.timeScale == 1)
    {
      coordinates = Mathf.Floor(_dest.x).ToString() + "\t" + Mathf.Floor(_dest.y).ToString() + "\t" + time.ToString() + "\t" + (transform.position.x - elbowTracker.transform.position.x).ToString() + "\t" + (transform.position.y - elbowTracker.transform.position.y).ToString() + "\t" + (transform.position.z - elbowTracker.transform.position.z).ToString() + "\n";
      File.AppendAllText(path, coordinates);
      File.AppendAllText(dataPath, coordinates);
      counter++;

      if (counter > 60)
      {
        readyText.text = "3";
      }
      if (counter > 120)
      {
        readyText.text = "2";
      }
      if (counter > 180)
      {
        readyText.text = "1";
      }
    }
    

    if (Input.GetKeyDown(KeyCode.Return))
    {
      playerName = inputField.GetComponent<Text>().text;
      CreateText();
      Hide();
      Time.timeScale = 1;
      string coordinateTitle = "Coordinates:\n";
      File.AppendAllText(path, coordinateTitle);
    }
    else if(Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
  }

  private void OnApplicationQuit()
  {
    string playtime = "Playtime: " + time.ToString() + " seconds\n";
    string keypressTitle = "Movements:\n";
    File.AppendAllText(path, keypressTitle);
    File.AppendAllText(path, keyPresses);
    File.AppendAllText(path, playtime);
  }
}
