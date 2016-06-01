using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 36;
    public int score = 0;
    public float resetDelay = 1f;
    public Text livesText;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    


    public static GM instance = null;


    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        for (int i = 1; i <5; i++)
        {
            for (int j = -4; j < 5; j++)
            {
                GameObject NewBrick = (GameObject)Instantiate(bricksPrefab, new Vector3(3 * j, 2 * i), Quaternion.identity);
                NewBrick.GetComponent<brickBehavior>().score = -1+2*i;
                bricks = 36;
            }
        }
    }

    void CheckGameOver()
    {
        if (bricks< 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
}

        if (lives< 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick(int deltascore)
    {
        bricks--;
        score= score +deltascore;
        scoreText.text = "score: " + score;
        CheckGameOver();
    }
}
