using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public float xLoc, yLoc;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        xLoc = 0;
        yLoc = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
        Debug.Log("Left");
        xLoc -= speed;
        }

        if(Input.GetKey(KeyCode.D)) {
        Debug.Log("Right");
        xLoc += speed;
        }

        //update the position
        this.transform.position = new Vector3(xLoc, yLoc, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Circle") {
            Destroy(other.gameObject);
        }
    }
}
