using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Task 2 done by Shania Clarke
    private GameManager gameManager;
    public GameObject coin;

    void Start()
    {
        //Accesses gameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }

    //Checks for player collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CoinCollect();
        }
    }

    //Increases the score and destroys coin
    public void CoinCollect()
    {
        gameManager.score += 1;
        Destroy(coin);
        gameManager.waitTime = 0f;
    }   
}
