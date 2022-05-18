using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnpoint;
    [SerializeField] float maxspawnPointX;
    [SerializeField] GameObject menuPanel;

    bool gameStarted = false;
    int score = 0;
    int highScore = 0;

    public static GameManager gameManager;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;


    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = "High Score :" + highScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !gameStarted)
        {
            menuPanel.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            StartCoroutine("SpawnEnemies");
            gameStarted = true;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(0.8f);
        }
    }




    public void Spawn()
    {
        // tehdään enemyn spawnausta varten  satunnainen paikka
        float randomSpawnX = Random.Range(-maxspawnPointX, maxspawnPointX);

        Vector3 enemySpawnPos = spawnpoint.position;
        enemySpawnPos.x = randomSpawnX;

        // spawnataan enemy satunnaiseen paikkaan
        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
    }

    public void Restart()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        SceneManager.LoadScene(0);
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }




}
