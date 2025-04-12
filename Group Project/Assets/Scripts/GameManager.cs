using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // Enemy prefabs
    public GameObject enemyBasicPrefab;
    public GameObject enemyFlowPrefab;
    public GameObject enemyAttackPrefab;

    // Playable area definition
    public float horizontalScreenLimit;
    public float verticalScreenLimitUpper;
    public float verticalScreenLimitLower;
    public float screenTop;

    public GameObject cloudPrefab;
    private int cloudLimit = 30;

    public GameObject playerPrefab;
    public GameObject audioPlayer;

    public AudioClip loseTrack;

    // UI text
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverText;
    public GameObject restartText;

    public int score;
    public int cloudMove;

    private bool gameOver;
    // Pickups
    public GameObject coinPrefab;
    public GameObject heartPrefab;
    public GameObject powerupPrefab;



    // Start is called before the first frame update
    void Start()
    {
        // Set playable area
        horizontalScreenLimit = 9.5f;
        verticalScreenLimitUpper = 0f;
        verticalScreenLimitLower = -3.5f;
        screenTop = 6.5f;

        // Set score to 0 at start
        score = 0;
        UpdateScoreText();

        // Spawn player and enemies
        Instantiate(playerPrefab, transform.position, Quaternion.identity);

        InvokeRepeating("CreateEnemyBasic", 1, 2);
        InvokeRepeating("CreateEnemyFlow", 1.5f, 3f);
        InvokeRepeating("CreateEnemyAttack", 3f, 5f);

        InvokeRepeating("CreateCoin", 5f, 5f);
        InvokeRepeating("CreateHeart", 5f, 7f);

        CreateSky();

        //Cloud movement
        cloudMove = 1;

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void CreateEnemyBasic()
    {
        Instantiate(enemyBasicPrefab, new Vector3(Random.Range(-horizontalScreenLimit, horizontalScreenLimit), screenTop, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateEnemyFlow()
    {
        // Flow enemies only spawn on the right side of the screen
        Instantiate(enemyFlowPrefab, new Vector3(Random.Range(0, horizontalScreenLimit), screenTop, 0), Quaternion.Euler(0, 0, Random.Range(135f, 180f)));
    }

    void CreateEnemyAttack()
    {
        // Attack enemies spawn at the right edge of the screen and move to the left
        Instantiate(enemyAttackPrefab, new Vector3(horizontalScreenLimit, Random.Range(2f, 5f), 0), Quaternion.Euler(0, 0, 90));
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(-horizontalScreenLimit, Random.Range(verticalScreenLimitUpper * 0.9f, verticalScreenLimitLower * 0.9f), 0), Quaternion.identity);
    }

    void CreateHeart()
    {
        Instantiate(heartPrefab, new Vector3(-horizontalScreenLimit, Random.Range(verticalScreenLimitUpper * 0.9f, verticalScreenLimitLower * 0.9f), 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < cloudLimit; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenLimit, horizontalScreenLimit), Random.Range(verticalScreenLimitLower, screenTop), 0), Quaternion.identity);
        }
    }

    public void UpdateLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void PlaySound(int whichSound)
    {
        switch (whichSound)
        {
            case 1:
                
                break;

            case 2:

                break;

            case 3:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(loseTrack);

                break;
        }
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke();
        cloudMove = 0;
        PlaySound(3);
    }
}
