using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int lives;
    public int points;
    public GameObject gameOverScreen;

    public static GameManager S;
    
    // Start is called before the first frame update
    void Awake() {
        S = this;
    }

    void Start() {
        lives = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife() {
        lives -= 1;
        if (lives < 1) {
            gameOverScreen.SetActive(true);
        }
    }
    
    public void AddPoint(int numPoints) {
        points += numPoints;
    }

    // public void RestartGame() {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

}
