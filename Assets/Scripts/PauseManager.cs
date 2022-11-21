using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private GameManager gameManager;
    public static bool gameIsPaused { get; private set; }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        gameManager.Pause(gameIsPaused);
        if (gameIsPaused) {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
