using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private int lives;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        lives = 3;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                    restartText.text = "PRESS 'X' TO RESTART";
                    restart = true;
                    break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "LIVES: " + lives + " / POINTS: " + score;
        if (score >= 1000)
        {
            gameOverText.text = "YOU WIN! GAME CREATED BY YNA CAMAGAY";
            FindObjectOfType<SoundEffects>().WinSound();
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER! GAME CREATED BY YNA CAMAGAY";
        FindObjectOfType<SoundEffects>().DeathSound();
        gameOver = true;
        restart = true;
    }


    //LIVES
    public void MinusLives(int newLifeValue)
    {
        lives -= newLifeValue;
        UpdateScore();
    }
}
