using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    int lives = 3;

    int balls = 1;
    [SerializeField] Transform ballSpawnPoint;
    [SerializeField] GameObject ballPrefab;

    [SerializeField] int brickCount = 10;

    [SerializeField] UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHit()
    {
        brickCount--;
        if (brickCount <= 0)
        {
            // level complete
            uiController.displayResults(true);
            Time.timeScale = 0;
        }
    }

    public void onAbyss()
    {
        balls--;
        if (balls <= 0)
        {
            lives--;
            uiController.updateLives(lives);
            if (lives <= 0)
            {
                // game over
                uiController.displayResults(false);
                Time.timeScale = 0;
            }
            else
            {
                // spawn a new ball
                spawnBall();
            }
        }
    }

    public void retry()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNames.MainMenu.ToString());
    }

    public void spawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPoint);
        balls++;
    }
}
