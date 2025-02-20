using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPaddle : MonoBehaviour {
    public float      paddleSpeed = .05f;
    public float      leftWall, rightWall;

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float clampedX = Mathf.Clamp(mousePosition.x, leftWall, rightWall);

        transform.localPosition = new Vector3(clampedX, transform.position.y, 0);
    }
}

