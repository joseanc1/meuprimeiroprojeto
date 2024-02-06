using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public GameObject screenEndGame;

    public BallController ballController;
    
    //contabilizando pontos
    public int playerScore = 0;
    public int enemyScore = 0;

    
    public int winPoints;

    public TextMeshProUGUI textEndGame;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    
    void Start()
    {
        ResetGame();
        
    }

    private void Update()
    {
        //resete do jogo quando quiser 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }
    

    public void CheckWin()
    {
        
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner + " Pontos :" + winPoints;
        SaveController.Instance.SaveWinner(winner);
        
        Invoke("LoadMenu", 2f);
    }
    
    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }
    
   
    public void ResetGame()
    {

        //Define as posições iniciais das raquetes
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);
        
        

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();
        
        screenEndGame.SetActive(false);
        
        //inserindo dentro do ResetGame
        ballController.ResetBall();
    }
    
}
