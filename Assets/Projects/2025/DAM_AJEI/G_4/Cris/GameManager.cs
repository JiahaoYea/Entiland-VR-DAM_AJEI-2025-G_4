using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playing = true;
    public static bool overTime = false;
    public static float gameTimer;

    [SerializeField]
    private GameObject lose;
    [SerializeField]
    private GameObject canvasPlayer;
    [SerializeField]
    private TextMeshProUGUI timeAlive;
    [SerializeField]
    private GameObject timeManager;

    private void Start()
    {
        canvasPlayer.SetActive(true);
        lose.SetActive(false);
        Time.timeScale = 1.0f;

        if (SceneManager.GetActiveScene().name == "Cris")
        {
            RestartGameState();
            gameTimer = 300f; 
        }
    }

    private void Update()
    {
        if (!playing)
        {
            Time.timeScale = 0;
            return;
        }

        if (overTime)
            HandleGameOver();
    }

    private void HandleGameOver()
    {
        timeManager.SetActive(false);
        canvasPlayer.SetActive(false);
        lose.SetActive(true);

        int minutes = Mathf.FloorToInt(TimeManager.playerTimer / 60); 
        int seconds = Mathf.FloorToInt(TimeManager.playerTimer % 60);
        timeAlive.text = $"{minutes}:{seconds:00}";

        playing = false;
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void RestartGameState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (lose != null)
            lose.SetActive(false);

        playing = true;
        overTime = false;
        canvasPlayer.SetActive(true);
    }
}
