using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayerManager : MonoBehaviour {
    public GameObject brick;

    public int rows, columns;
    public float brickWidth = 0.5f;
    public float brickHeight = 0.5f;
    public float brickSpacing = 0.1f;
    private float offsetY = 2.65f;
    // private float offsetX = 0.5f;

    void Start() {
        float totalWidth = columns * (brickWidth + brickSpacing) - brickSpacing;
        float totalHeight = rows * (brickHeight + brickSpacing) - brickSpacing;

        Vector2 startPos = new Vector2(-totalWidth / 2f + brickWidth / 2f, totalHeight / 2f - brickHeight / 2f + offsetY);

        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                float xPos = startPos.x + i * (brickWidth + brickSpacing);
                float yPos = startPos.y - j * (brickHeight + brickSpacing);
                
                Instantiate(brick, new Vector3(xPos, yPos, 0), Quaternion.identity).transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


