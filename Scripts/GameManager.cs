using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Task 1 edits done by Cami Alarcon-Fernandez
    //Task 2 Edits done by Shania Clarke
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;
    //Task 2 Variable
    public float waitTime = 8f;
    

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        StartCoroutine(CreateCoins());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
    }

    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    //Task 2 Function
    private IEnumerator CreateCoins()
    {
        while (true)
        {
            GameObject coin = Instantiate(coinPrefab, new Vector3(Random.Range(-4, 5), Random.Range(-5, 5), 0), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            Destroy(coin);
            waitTime = 8f;
        }
    
    //Task 1 Function
    public void ChangeScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
