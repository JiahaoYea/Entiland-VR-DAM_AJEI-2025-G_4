using DG.Tweening.Core.Easing;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float playerTimer = 300f;  
    public static float gameTimer;     
    private bool stillAlive = true;  

    [SerializeField] TextMeshProUGUI timer;             
    public static TextMeshProUGUI timerLose;            

    private void Start()
    {
        gameTimer = GameManager.gameTimer; 
        stillAlive = true;
    }

    void Update()
    {
        if (stillAlive)
        {
            int minutes = Mathf.FloorToInt(playerTimer / 60);
            int seconds = Mathf.FloorToInt(playerTimer % 60);

            timer.text = $"{minutes}:{seconds:00}";
            playerTimer -= Time.deltaTime;

            if (playerTimer <= 0)
            {
                GameManager.overTime = true;
                stillAlive = false;
            }
        }

        if (timerLose != null)
        {
            int minutesT = Mathf.FloorToInt(gameTimer / 60);
            int secondsT = Mathf.FloorToInt(gameTimer % 60);
            timerLose.text = $"Time: {minutesT}:{secondsT:00}";
        }

        if (stillAlive)
            gameTimer -= Time.deltaTime;
        
    }
    public void UpdateTime(float timeToModify)
    {
        playerTimer += timeToModify;
    }
}
