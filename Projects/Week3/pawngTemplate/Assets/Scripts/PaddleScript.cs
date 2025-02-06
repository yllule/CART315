using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    private float     yPos;
    public float      paddleSpeed = .05f;

	public KeyCode	  upKey, downKey;
	public float	  topWall, bottomWall;

    public float shrinkAmount = 0.1f;
    public float minPaddleSize = 0.3f;

    public float growAmount = 0.1f;
    public float maxPaddleSize = 1f;
	
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(downKey) && yPos > bottomWall) {
                yPos -= paddleSpeed;
        }

        if (Input.GetKey(upKey) && yPos < topWall) {
                yPos += paddleSpeed;
        }

        transform.localPosition = new Vector3(transform.position.x, yPos, 0);
    }

    //makes it possible for paddles to shrink
    public void ShrinkPaddle() {
        Vector3 newSize = transform.localScale;
        newSize.y = Mathf.Max(newSize.y - shrinkAmount, minPaddleSize);
        transform.localScale = newSize;
    }

    //makes it possible for paddles to grow
    public void GrowPaddle() {
        Vector3 newSize = transform.localScale;
        newSize.y = Mathf.Max(newSize.y + growAmount, maxPaddleSize);
        transform.localScale = newSize;
    }
}

