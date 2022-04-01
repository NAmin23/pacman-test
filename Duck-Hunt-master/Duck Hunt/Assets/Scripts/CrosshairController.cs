using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{

    public GameObject handTracker;
    public GameObject elbowTracker;
    public bool duckHit = false;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true)
        {
      transform.position = new Vector3(handTracker.transform.position.x - elbowTracker.transform.position.x, handTracker.transform.position.y - elbowTracker.transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Duck")
        {
            duckHit = true;
            Debug.Log("hit!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Duck")
        {
            duckHit = false;
        }
    }
}
